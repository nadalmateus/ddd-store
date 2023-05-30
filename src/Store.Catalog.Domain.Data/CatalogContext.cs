using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;

using Store.Core.Data;

namespace Store.Catalog.Domain.Data;

public class CatalogContext : DbContext, IUnitOfWork
{
    public CatalogContext(DbContextOptions<CatalogContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    public async Task<bool> Commit()
    {
        foreach (EntityEntry entry in ChangeTracker.Entries()
                     .Where(entry => entry.Entity.GetType().GetProperty("RegisterDate") != null))
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property("RegisterDate").CurrentValue = DateTime.Now;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property("RegisterDate").IsModified = false;
            }
        }

        return await base.SaveChangesAsync() > 0;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (IMutableProperty property in modelBuilder.Model.GetEntityTypes()
                     .SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
        {
            property.SetColumnType("varchar(100)");
        }

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogContext).Assembly);
    }
}
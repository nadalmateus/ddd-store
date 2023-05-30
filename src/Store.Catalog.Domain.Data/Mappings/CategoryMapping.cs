﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Store.Catalog.Domain.Data.Mappings
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).IsRequired().HasColumnType("varchar(250)");

            builder.HasMany(c => c.Products).WithOne(c => c.Category).HasForeignKey(p => p.CategoryId)
                .HasForeignKey(p => p.CategoryId);

            builder.ToTable("Categories");
        }
    }
}
using Store.Catalog.Application.Services;
using Store.Catalog.Domain;
using Store.Catalog.Domain.Data;
using Store.Catalog.Domain.Data.Repository;
using Store.Core.Bus;

namespace Store.WebApp.MVC.Setup
{
    public static class DependenceInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductAppService, ProductAppService>();
            services.AddScoped<IStockService, StockService>();
            services.AddScoped<CatalogContext>();
        }
    }
}
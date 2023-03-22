using CatalogAPI.Domain.Interfaces;
using CatalogAPI.Domain.Application.Mappings;
using CatalogAPI.Domain.Application.Interfaces;
using CatalogAPI.Domain.Application.Services;
using CatalogAPI.Infra.Data.Context;
using CatalogAPI.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogAPI.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext)
                    .Assembly.FullName)));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddAutoMapper(typeof(ProfileConfiguration));

            return services;
        }
    }
}

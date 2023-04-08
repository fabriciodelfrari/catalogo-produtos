using CatalogAPI.Domain.Interfaces;
using CatalogAPI.Domain.Application.Mappings;
using CatalogAPI.Domain.Application.Interfaces;
using CatalogAPI.Domain.Application.Services;
using CatalogAPI.Infra.Data.Context;
using CatalogAPI.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using CatalogAPI.Domain.Interfaces.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CatalogAPI.Domain.Interfaces.Token;
using CatalogAPI.Infra.Data.Services;
using CatalogAPI.Infra.CrossCutting.Authentication.Services;
using CatalogAPI.Infra.Data.Identity;
using CatalogAPI.Infra.CrossCutting.Authentication.Mappings;

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

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Configuração de autenticação JWT
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetSection("Jwt")["SecretKey"]!)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowPostman",
                    builder => builder.WithOrigins("https://www.getpostman.com")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod());
            });


            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

            services.AddScoped<ITokenService, TokenService>();

            services.AddAutoMapper(typeof(ProfileConfiguration));
            services.AddAutoMapper(typeof(LoginProfileConfiguration));

            return services;
        }
    }
}

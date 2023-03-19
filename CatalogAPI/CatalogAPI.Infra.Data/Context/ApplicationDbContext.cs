using Microsoft.EntityFrameworkCore;
using CatalogAPI.Domain.Entities;

namespace CatalogAPI.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set;}
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //aplica as configurações das entidades em CatalogAPI.Infra.Data.Configurations.Entities
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}

using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure.Persistencs.DbContexts
{
    public class StoreDbContext(DbContextOptions<StoreDbContext> options)
        : DbContext(options)
    {
        public DbSet<Product> Products => Set<Product>(); 
        public DbSet<ProductBrand> Brands => Set<ProductBrand>();
        public DbSet<ProductType> Types => Set<ProductType>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}

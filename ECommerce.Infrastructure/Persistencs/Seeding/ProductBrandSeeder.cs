using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Persistencs.DbContexts;
using ECommerce.Infrastructure.Persistencs.Seeding.Data;
using ECommerce.Infrastructure.Persistencs.Seeding.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure.Persistencs.Seeding
{
    public class ProductBrandSeeder(StoreDbContext dbContext) : IDdataSeeder
    {
        public int odrder => 1;

        public async Task SeedAsync(CancellationToken ct = default)

                => await JsonSeeder.SeedIfEmpty<ProductBrand, ProductBrandSeedModel>
            (dbContext.Brands, "brands.json", b => ProductBrand.Create(b.Id, b.Name), ct);
    }
}

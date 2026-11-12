using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Persistencs.DbContexts;
using ECommerce.Infrastructure.Persistencs.Seeding.Data;
using ECommerce.Infrastructure.Persistencs.Seeding.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure.Persistencs.Seeding
{
    public class ProductTypeSeeder(StoreDbContext dbContext) : IDdataSeeder
    {
        public int odrder => 2;

        public async Task SeedAsync(CancellationToken ct = default)

                => await JsonSeeder.SeedIfEmpty<ProductType, ProductTypeSeedModel>
            (dbContext.Types, "types.json", t => ProductType.Create(t.Id, t.Name), ct);
    }
}

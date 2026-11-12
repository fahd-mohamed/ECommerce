using ECommerce.Infrastructure.Persistencs.DbContexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure.Persistencs.Seeding
{
    public sealed class DatabaseSeeder(StoreDbContext dbContext,
        IEnumerable<IDdataSeeder> seeders)
    {
        public async Task SeedAll(CancellationToken ct = default)
        {
            foreach (var seeder in seeders.OrderBy(s => s.odrder))
            {
                await seeder.SeedAsync(ct);
                await dbContext.SaveChangesAsync(ct);
            }
        }
    }

    
}

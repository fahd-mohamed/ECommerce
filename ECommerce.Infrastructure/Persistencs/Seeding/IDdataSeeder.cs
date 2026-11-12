using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure.Persistencs.Seeding
{
    public interface IDdataSeeder
    {
        int odrder { get; }
        
        Task SeedAsync(CancellationToken ct = default);
    }
}

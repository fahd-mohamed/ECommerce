using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace ECommerce.Infrastructure.Persistencs.Seeding.Data
{
    public static class JsonSeeder
    {
        private static readonly JsonSerializerOptions options = new  ()
        {
            PropertyNameCaseInsensitive = true
        };
        public static async Task SeedIfEmpty<TEntity, TModel>(
            DbSet<TEntity> dbSet,
            string fileName,
            Func<TModel, TEntity> map,
            CancellationToken ct = default
            ) where TEntity : BaseEntity
             
        { 
            if(await dbSet.AnyAsync(ct))
                            return;
            
            var filePath = Path.Combine(AppContext.BaseDirectory, "Persistencs", "Seeding", "Data", fileName);
            if(!File.Exists(filePath))return;

            await using var stream = File.OpenRead(filePath);
            var models = await JsonSerializer.DeserializeAsync<List<TModel>>(stream, options, ct);
            if(models is  null || !models.Any()) return;

          
            await dbSet.AddRangeAsync(models.Select(map), ct);
        }
    }
}

using ECommerce.Domain.UnitOfWork;
using ECommerce.Infrastructure.Persistencs.DbContexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure.UnitOfWorks
{
    public class UnitOfWork(StoreDbContext dbcontext) : IUnitOfWork
    {
        private readonly StoreDbContext _dbContext = dbcontext;
        public async Task<int> SaveChangesAsync(CancellationToken ct = default)
        {
             return await _dbContext.SaveChangesAsync(ct);
        }
    }
}

using ECommerce.Domain.Entities;
using ECommerce.Domain.Repositories;
using ECommerce.Infrastructure.Persistencs.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure.Repositories
{
    public sealed class Repository<T>(StoreDbContext dbcontext)
        : IRepository<T> where T : BaseEntity
    {
        private readonly DbSet<T> _dbSet = dbcontext.Set<T>();
        public async Task<T?> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            return await _dbSet.FindAsync([id], ct);
        }


        public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken ct = default)
        {
            return await _dbSet.AsNoTracking().ToListAsync(ct);
        }
        public void Add(T entity)
        {
           _dbSet.Add(entity);
        }


        public void Update(T entity)
        {
           _dbSet.Update(entity);
        }
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
  
    }
}

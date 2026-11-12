using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domain.UnitOfWork
{
    public interface IUnitOfWork 
    {
        Task<int> SaveChangesAsync(CancellationToken ct = default);
    }
}

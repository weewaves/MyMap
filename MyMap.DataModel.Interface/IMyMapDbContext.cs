using Microsoft.EntityFrameworkCore;
using MyMap.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyMap.DataModel.Interface
{
    public interface IMyMapDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken));

        DbSet<WayPoint> WayPoints { get; set; }
    }
}

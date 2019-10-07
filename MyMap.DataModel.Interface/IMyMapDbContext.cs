using Microsoft.EntityFrameworkCore;
using MyMap.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyMap.DataModel.Interface
{
    public interface IMyMapDbContext: IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken));

        DbSet<Spot> Spots { get; set; }

        DbSet<Area> Areas { get; set; }
    }   
}

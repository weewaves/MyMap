using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyMap.DataModel.Interface;
using MyMap.Domain;

namespace MyMap.DataModel
{
    public class MyMapDbContext : DbContext, IMyMapDbContext
    {
        public MyMapDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Spot> Spots { get; set; }

        public DbSet<Area> Areas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var internalBuilder = modelBuilder.GetInfrastructure();

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                internalBuilder
                    .Entity(entity.Name, ConfigurationSource.Convention)
                    .Relational(ConfigurationSource.Convention)
                    .ToTable(entity.ClrType.Name);
            }
        }
    }
}
    
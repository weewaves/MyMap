using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyMap.Business.Interface;
using MyMap.Business.Model;
using MyMap.Business.Model.WayPoint;
using MyMap.Common;
using MyMap.DataModel.Interface;
using MyMap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMap.Business
{
    public class WayPointService : ServiceBase, IWayPointService
    {
        public WayPointService(IMyMapDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        { }

        public async Task<BusinessResult<Guid>> CreateWayPoint(WayPointModel wayPointModel)
        {
            var wayPointEntity = Mapper.Map<WayPoint>(wayPointModel);

            wayPointEntity.CreatedDate = DateTime.Now;

            DbContext.WayPoints.Add(wayPointEntity);

            await DbContext.SaveChangesAsync(true);

            return CreateSuccessResult(wayPointEntity.Id);
        }

        public async Task<IEnumerable<WayPointModel>> LoadWayPointCollectionByRegion(MapRegion mapRegion, int maxNumberOfWayPoints = 10)
        {
            var wayPointModels = await DbContext
                                        .WayPoints
                                        .Where(rwp => !rwp.Disabled &&
                                                       mapRegion.Contains(new Coordinate(rwp.Latitude.Value, rwp.Longitude.Value)))
                                        .Select(rwp => new WayPointModel
                                        {
                                            Id = rwp.Id,
                                            Height = rwp.Height,
                                            Latitude = rwp.Latitude,
                                            Longitude = rwp.Longitude,
                                            Name = rwp.Name,
                                            Type = rwp.Type
                                        })
                                        .Take(maxNumberOfWayPoints)
                                        .ToListAsync();

            return wayPointModels;
        }
    }
}

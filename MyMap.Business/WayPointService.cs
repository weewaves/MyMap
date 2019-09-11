using AutoMapper;
using MyMap.Business.Interface;
using MyMap.Business.Model.WayPoint;
using MyMap.Common;
using MyMap.DataModel.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyMap.Business
{
    public class WayPointService : ServiceBase, IWayPointService
    {
        public WayPointService(IMyMapDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        { }

        public async Task<IEnumerable<WayPointModel>> FetchWaypointsWithinMapRegionAsync(MapRegion mapRegion, int maxNumberOfWayPoints = 10)
        {
            var list = new List<WayPointModel>
            {
                new WayPointModel
                {
                    Id = Guid.NewGuid(),
                    Name = "ABC"
                },
                new WayPointModel
                {
                    Id = Guid.NewGuid(),
                    Name = "ABC"
                },
                new WayPointModel
                {
                    Id = Guid.NewGuid(),
                    Name = "ABC"
                },
                new WayPointModel
                {
                    Id = Guid.NewGuid(),
                    Name = "ABC"
                },
                new WayPointModel
                {
                    Id = Guid.NewGuid(),
                    Name = "ABC"
                },
                new WayPointModel
                {
                    Id = Guid.NewGuid(),
                    Name = "ABC"
                }
            };

            return list;
        }
    }
}

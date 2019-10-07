using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyMap.Business.Interface;
using MyMap.Business.Model;
using MyMap.Business.Model.Spot;
using MyMap.Common;
using MyMap.DataModel.Interface;
using MyMap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMap.Business
{
    public class SpotService : ServiceBase, ISpotService
    {
        public SpotService(IMyMapDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        { }

        public async Task<BusinessResult<Guid>> CreateSpot(SpotModel SpotModel)
        {
            var spotEntity = Mapper.Map<Spot>(SpotModel);

            spotEntity.CreatedDate = DateTime.Now;

            DbContext.Spots.Add(spotEntity);

            await DbContext.SaveChangesAsync(true);

            return CreateSuccessResult(spotEntity.Id);
        }

        public async Task<IEnumerable<SpotModel>> LoadSpotCollectionByRegion(MapArea mapRegion, int maxNumberOfSpots = 10)
        {
            var spotModels = await DbContext
                                        .Spots
                                        .Where(rwp => !rwp.Disabled &&
                                                       mapRegion.Contains(new Coordinate(rwp.Latitude.Value, rwp.Longitude.Value)))
                                        .Select(rwp => new SpotModel
                                        {
                                            Id = rwp.Id,
                                            Height = rwp.Height,
                                            Latitude = rwp.Latitude,
                                            Longitude = rwp.Longitude,
                                            Name = rwp.Name,
                                            Type = rwp.Type
                                        })
                                        .Take(maxNumberOfSpots)
                                        .ToListAsync();

            return spotModels;
        }
    }
}

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

        public async Task<IEnumerable<SpotModel>> LoadSpotCollectionByViewPort(MapViewPort mapViewPort, int maxNumberOfSpots = 10)
        {
            var spotModels = await DbContext
                                        .Spots
                                        .Where(sp => !sp.Disabled &&
                                                       mapViewPort.Contains(new Coordinate(sp.Latitude.Value, sp.Longitude.Value)))
                                        .Select(sp => new SpotModel
                                        {
                                            Id = sp.Id,
                                            AreaId=sp.AreaId,
                                            PictureUrls = sp.PictureUrls,
                                            Vote = sp.Vote,
                                            Height = sp.Height,
                                            Latitude = sp.Latitude,
                                            Longitude = sp.Longitude,
                                            Name = sp.Name,
                                            Type = sp.Type
                                        })
                                        .Take(maxNumberOfSpots)
                                        .ToListAsync();

            return spotModels;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyMap.Business.Model;
using MyMap.Business.Model.Spot;
using MyMap.Common;

namespace MyMap.Business.Interface
{
    public interface ISpotService
    {
        Task<IEnumerable<SpotModel>> LoadSpotCollectionByRegion(MapViewPort mapRegion, int maxNumberOfSpots);
        Task<BusinessResult<Guid>> CreateSpot(SpotModel spotModel);
    }
}

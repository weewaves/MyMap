using System.Collections.Generic;
using System.Threading.Tasks;
using MyMap.Business.Interface;
using MyMap.Business.Model.WayPoint;
using MyMap.Common;
    
namespace MyMap.Business
{
    public class WayPointService : IWayPointService
    {
        public WayPointService()
        {
        }

        public Task<IEnumerable<WayPointModel>> FetchWaypointsWithinMapRegion(MapRegion mapRegion, int maxNumberOfWayPoints = 10)
        {
            return null;
        }
    }
}

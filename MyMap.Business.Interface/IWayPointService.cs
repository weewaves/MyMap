using System.Collections.Generic;
using System.Threading.Tasks;
using MyMap.Business.Model.WayPoint;
using MyMap.Common;

namespace MyMap.Business.Interface
{
    public interface IWayPointService
    {
        Task<IEnumerable<WayPointModel>> FetchWaypointsWithinMapRegion(MapRegion mapRegion, int maxNumberOfWayPoints);
    }
}

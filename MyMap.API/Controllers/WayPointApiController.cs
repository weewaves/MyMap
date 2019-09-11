using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyMap.Common;

namespace MyMap.API.Controllers
{
    [Produces("application/json")]
    public class WayPointApiController : ControllerBase<WayPointApiController>
    {
        [HttpPost]
        [Route("api/FetchWaypointsWithinMapRegion")]
        public async Task<object> Post([FromBody] MapRegion mapRegion)
        {
            try
            {
                return null;
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, exception.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
    }
}

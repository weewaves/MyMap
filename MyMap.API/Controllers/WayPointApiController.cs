using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyMap.Business.Interface;
using MyMap.Common;

namespace MyMap.API.Controllers
{
    [Produces("application/json")]
    public class WayPointApiController : ControllerBase<WayPointApiController>
    {
        private IWayPointService _wayPointService;

        public WayPointApiController(
            IConfiguration configuration,
            ILogger<WayPointApiController> logger,
            IMapper mapper,
            IWayPointService wayPointService) : base(configuration, logger, mapper)
        {
            _wayPointService = wayPointService;
        }

        [HttpPost]
        [Route("api/LoadWayPointCollectionByRegion")]
        public async Task<object> Post([FromBody] MapRegion mapRegion)
        {
            try
            {
                return _wayPointService.LoadWayPointCollectionByRegion(mapRegion, 50);
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, exception.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
    }
}

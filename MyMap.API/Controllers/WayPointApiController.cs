using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyMap.API.Model.WayPoint;
using MyMap.Business.Interface;
using MyMap.Business.Model.WayPoint;
using MyMap.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyMap.API.Controllers
{
    [Produces("application/json")]
    [EnableCors("AllowOrigin")]
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
        [Route("api/waypoint")]
        public async Task<object> Post([FromBody] CreateWayPointContract waypointViewModel)
        {
            try
            {
                var wayPointModel = Mapper.Map<WayPointModel>(waypointViewModel);

                return await _wayPointService.CreateWayPoint(wayPointModel);
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, exception.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Route("api/LoadWayPointCollectionByRegion")]
        public async Task<object> Post([FromBody] MapRegion mapRegion)
        {
            try
            {
                IEnumerable<WayPointModel> results = await _wayPointService.LoadWayPointCollectionByRegion(mapRegion, 50);

                return Mapper.Map<IEnumerable<WayPointContract>>(results);
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, exception.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
    }
}

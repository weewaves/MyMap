using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyMap.API.Model.Spot;
using MyMap.Business.Interface;
using MyMap.Business.Model.Spot;
using MyMap.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyMap.API.Controllers
{
    [Produces("application/json")]
    [EnableCors("AllowOrigin")]
    public class SpotApiController : ControllerBase<SpotApiController>
    {
        private ISpotService _spotService;

        public SpotApiController(
            IConfiguration configuration,
            ILogger<SpotApiController> logger,
            IMapper mapper,
            ISpotService spotService) : base(configuration, logger, mapper)
        {
            _spotService = spotService;
        }

        [HttpPost]
        [Route("api/spot")]
        public async Task<object> Post([FromBody] CreateSpotContract contract)
        {
            try
            {
                var model = Mapper.Map<SpotModel>(contract);

                return await _spotService.CreateSpot(model);
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, exception.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Route("api/LoadSpotCollectionByRegion")]
        public async Task<object> Post([FromBody] MapArea mapRegion)
        {
            try
            {
                IEnumerable<SpotModel> results = await _spotService.LoadSpotCollectionByRegion(mapRegion, 50);

                return Mapper.Map<IEnumerable<SpotContract>>(results);
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, exception.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
    }
}

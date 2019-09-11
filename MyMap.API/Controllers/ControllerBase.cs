using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MyMap.API.Controllers
{
    public class ControllerBase<T> : Controller where T : Controller
    {
        public ControllerBase()
        {
            Configuration = null;
        }

        public ControllerBase(IConfiguration configuration, ILogger<T> logger, IMapper mapper)
        {
            Configuration = configuration;
            Logger = logger;
            Mapper = mapper;
        }

        protected ILogger<T> Logger { get; }

        protected IMapper Mapper { get; }

        protected IConfiguration Configuration { get; }
    }
}

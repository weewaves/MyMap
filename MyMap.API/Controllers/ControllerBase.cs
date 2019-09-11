using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MyMap.API.Controllers
{
    public class ControllerBase<T> : Controller where T : Controller
    {
        private ILogger<T> logger;

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

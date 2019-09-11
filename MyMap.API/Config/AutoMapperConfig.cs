using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MyMap.API.Mapper;

namespace MyMap.API.Config
{
    public static class AutoMapperConfig    
    {
        public static void AddMyMapAutoMapper(this IServiceCollection services)
        {
            var thisAssembly = typeof(AutoMapperConfig).Assembly;
            var businessAssembly = typeof(WayPointProfile).Assembly;

            services.AddAutoMapper(thisAssembly, businessAssembly);
        }
    }
}

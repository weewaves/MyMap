using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace MyMap.API.Config
{
    public static class AutoMapperConfig    
    {
        public static void AddMyMapAutoMapper(this IServiceCollection services)
        {
            var thisAssembly = typeof(AutoMapperConfig).Assembly;
            var businessAssembly = typeof(Business.Mapper.SpotProfile).Assembly;

            services.AddAutoMapper(thisAssembly, businessAssembly);
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using MyMap.Business;
using MyMap.Business.Interface;
using MyMap.DataModel;
using MyMap.DataModel.Interface;

namespace MyMap.API.Config
{
    public static class DependencyConfig
    {
        public static void AddMyMapDependencies(this IServiceCollection services)
        {
            services.AddTransient<IMyMapDbContext, MyMapDbContext>();
            services.AddScoped<ISpotService, SpotService>();
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyMap.API.Config;
using MyMap.DataModel;

namespace MyMap.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AddDbContext(services);
            services.AddMvc();
            services.AddMyMapDependencies();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        protected virtual void AddDbContext(IServiceCollection services)
        {
            services.AddDbContext<MyMapDbContext>(
                options =>
                {
                    ConfigureContext(options);
                });
        }

        protected virtual void ConfigureContext(DbContextOptionsBuilder dbContextOptions)
        {
            dbContextOptions.UseNpgsql(
                        Configuration.GetConnectionString("DefaultConnection"));
            dbContextOptions.EnableSensitiveDataLogging();
        }
    }
}

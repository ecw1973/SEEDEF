﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Server
{
    public class Startup
    {
        #region Methods

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();

            services.AddHostedService<DataProducingBackgroundService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapHub<SimulationDataHub>(HubServiceApi.Strings.TestHubPath));
        }

        #endregion
    }
}
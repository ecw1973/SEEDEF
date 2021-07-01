using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HubServiceApi;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Server
{
    #region Worker

    public class DataProducingBackgroundService : BackgroundService
    {
        #region Fields

        private readonly ILogger<DataProducingBackgroundService> logger;
        private readonly IHubContext<SimulationDataHub, IHubTypeOne> simDataHub;

        #endregion

        #region Constructors

        public DataProducingBackgroundService(ILogger<DataProducingBackgroundService> logger, IHubContext<SimulationDataHub, IHubTypeOne> simDataHub)
        {
            this.logger = logger;
            this.simDataHub = simDataHub;
        }

        #endregion

        #region Methods

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                logger.LogInformation("Worker running at: {Time}", DateTime.Now);

                await simDataHub.Clients.All.PublishTime(DateTime.Now);
                await simDataHub.Clients.All.PublishListOfInt(new List<int>(){1,2,3});
                
                await Task.Delay(1000, stoppingToken);
            }
        }

        #endregion
    }

    #endregion
}
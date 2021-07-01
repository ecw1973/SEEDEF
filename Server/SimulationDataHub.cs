using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HubServiceApi;
using Microsoft.AspNetCore.SignalR;

namespace Server
{
    public class SimulationDataHub : Hub<IHubTypeOne>
    {
        #region Methods

        public async Task PublishTime(DateTime dateTime)
        {
            await Clients.All.PublishTime(dateTime);
        }

        public async Task PublishListOfInt(List<int> listOfInt)
        {
            await Clients.All.PublishListOfInt(listOfInt);
        }

        #endregion
    }
}
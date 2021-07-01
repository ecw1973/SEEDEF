using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HubServiceApi
{
    public interface IHubTypeOne
    {
        #region Methods

        Task PublishTime(DateTime currentTime);
        Task PublishListOfInt(List<int> listOfInt);

        #endregion
    }
}
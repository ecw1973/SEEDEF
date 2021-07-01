using System;
using System.Threading.Tasks;
using HubServiceApi;
using Microsoft.AspNetCore.SignalR.Client;

namespace Clients.ConsoleOne
{
    internal class Program
    {
        #region Methods

        private static async Task Main(string[] args)
        {
            HubConnection connection = new HubConnectionBuilder().WithUrl(Strings.TestHubUrl).Build();

            connection.On<DateTime>(Strings.Events.TimeReceived, dateTime => Console.WriteLine(dateTime.ToString()));

            // Loop here to wait until the server is running
            while (true)
            {
                try
                {
                    await connection.StartAsync();
                    Console.WriteLine("Client connected!");
                    break;
                }
                catch
                {
                    await Task.Delay(1000);
                }
            }

            Console.WriteLine("Client is listening. Hit Ctrl-C to quit.");
            Console.ReadLine();
        }

        #endregion
    }
}
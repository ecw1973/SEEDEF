using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using HubServiceApi;
using Microsoft.AspNetCore.SignalR.Client;

namespace SignalRChatClient
{
    public partial class MainWindow : Window
    {
        #region Fields

        private readonly HubConnection connection;

        #endregion

        #region Constructors

        public MainWindow()
        {
            InitializeComponent();

            connection = new HubConnectionBuilder().WithUrl(Strings.TestHubUrl).Build();



            // Reconnect Attempt....
            connection.Closed += async error =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };
        }

        #endregion

        private async void connectButton_Click(object sender, RoutedEventArgs e)
        {
            connection.On<DateTime>(Strings.Events.TimeReceived, (dateTime) =>
            {
                Dispatcher.Invoke(() =>
                {
                    string item = "Type: " + dateTime.GetType().Name + " Value: " + dateTime;
                    messagesList.Items.Add(item);
                });
            });

            connection.On<List<int>>(Strings.Events.ListOfIntReceived, (listOfInt) =>
            {
                Dispatcher.Invoke(() =>
                {
                    string item = "Type: " + listOfInt.GetType().Name + " Value: " + String.Join(",", listOfInt);
                    messagesList.Items.Add(item);
                });
            });

            try
            {
                await connection.StartAsync();
                messagesList.Items.Add("Connection started");
                connectButton.IsEnabled = false;
                disconnectButton.IsEnabled = true;
            }
            catch (Exception ex)
            {
                messagesList.Items.Add(ex.Message);
            }
        }

        private async void disconnectButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                messagesList.Items.Clear();
                await connection.StopAsync();
                connectButton.IsEnabled = true;
            }
            catch (Exception ex)
            {
                messagesList.Items.Add(ex.Message);
            }
        }

        //private async void sendButton_Click(object sender, RoutedEventArgs e)
        //{
        //    #region snippet_ErrorHandling

        //    try
        //    {
        //        #region snippet_InvokeAsync

        //        await connection.InvokeAsync("SendMessage",
        //            userTextBox.Text, messageTextBox.Text);

        //        #endregion
        //    }
        //    catch (Exception ex)
        //    {
        //        messagesList.Items.Add(ex.Message);
        //    }

        //    #endregion
        //}
    }
}
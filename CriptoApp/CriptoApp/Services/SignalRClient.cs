using CriptoApp.Models;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CriptoApp.Services
{
    public class SignalRClient
    {
        string url = "https://cryptoserviceapi.azurewebsites.net/";
        HubConnection Connection;
        IHubProxy CriptoHub;

        public delegate void Error();
        public delegate void MessageReceived(string ListCripto);

        public event Error ConnectionError;
        public event MessageReceived OnMessageReceived;

        public void Connect(string _username)
        {
            Connection = new HubConnection(url, new Dictionary
                <string, string>
            {
                { "name", _username }
            });


            CriptoHub = Connection.CreateHubProxy("ServiceHub");

            CriptoHub.On<string, string>("sendMessage",
                (name, message) =>
                {
                    OnMessageReceived?.Invoke(message);
                });

            Start().ContinueWith(task =>
            {
                if (task.IsFaulted)
                    ConnectionError?.Invoke();
            });
        }

        public void Stop()
        {
            try
            {
                if (Connection != null)
                    Connection.Stop();
            }
            catch (Exception)
            {

            }
        }

        public void SendMessage(string sender, string message)
        {
            try
            {
                CriptoHub.Invoke("SendMessage", sender, message);
            }
            catch (Exception ex)
            {

            }
        }

        private Task Start()
        {
            return Connection.Start();
        }
    }
}

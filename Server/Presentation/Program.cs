using Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Presentation
{
    class Program
    {
        private static WebSocketConnection socketConnection = null;
        private static RestaurantManager restaurantManager = new RestaurantManager();
        
        static void LogToConsole(string stringLog)
        {
            Console.WriteLine("Test");
        }
        public static async Task Main(string[] args)
        {
            RestaurantManager restaurantManager = new RestaurantManager();
            restaurantManager.AddSampleData();
            XmlSerializer xmlSerializer = new XmlSerializer(restaurantManager.GetType());

            RestaurantManager restaurant = new RestaurantManager();
            restaurant.AddSampleData();
            API api = new API(restaurant);
            
            TcpListener l = new TcpListener(IPAddress.Loopback, 0);
            l.Start();
            int port = 50216;// ((IPEndPoint)l.LocalEndpoint).Port;
            l.Stop();
            Console.WriteLine("Port: " + port);
            Action<WebSocketConnection> action = api.HandleConnectedClient;
            WebSocketServer.Server(port, action);

            while (true)
            {


                if (socketConnection != null)
                {
                    Console.WriteLine("Sending...");
                    await socketConnection.SendAsync("aa");
                }

            }
        }

        
    }
}

using ServerLogic;
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
    public class Program
    {
        private static WebSocketConnection socketConnection = null;
        private static RestaurantManager restaurantManager = new RestaurantManager();
        private static bool finish = false;

        public static void Stop()
        {
            finish = true;
        }
        
        public static async Task Main(string[] args)
        {
            RestaurantManager restaurantManager = new RestaurantManager();
            restaurantManager.AddSampleData();
            XmlSerializer xmlSerializer = new XmlSerializer(restaurantManager.GetType());

            RestaurantManager restaurant = new RestaurantManager();
            restaurant.AddSampleData();
            API api = new API(restaurant);
            int port;
            if (args.Length > 0)
            {
                port = Int32.Parse(args[0]);
            }
            else
            {
                TcpListener l = new TcpListener(IPAddress.Loopback, 0);
                l.Start();
                port = ((IPEndPoint)l.LocalEndpoint).Port;
                l.Stop();
            }
           
            Console.WriteLine("Port: " + port);
            Action<WebSocketConnection> action = api.HandleConnectedClient;
            WebSocketServer.Server(port, action);

            while (!finish)
            {
                
            }
        }

        
    }
}

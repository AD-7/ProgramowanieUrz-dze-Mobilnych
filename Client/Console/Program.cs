using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp.API;

namespace ConsoleApp
{
    class Program
    {
        public static void LogToConsole(string message)
        {
            Console.WriteLine(message);
        }
        static async Task Main(string[] args)
        {
            Console.WriteLine("Here");
            int p2p_port = 50216;
            Uri _uri = new Uri($@"ws://localhost:{p2p_port}/");
            WebSocketConnection socketConnection = await WebSocketClient.Connect(_uri, LogToConsole);
            socketConnection.onMessage = LogToConsole;
            API api = new API(socketConnection);
            //api.GetMenuFromServer();
            await socketConnection.SendAsync("GET_MENU_REQ");
            while (true)
            {
                //
            }
        }
    }
}

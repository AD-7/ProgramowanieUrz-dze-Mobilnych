using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public class SocketConnectionController
    {
        private WebSocketConnection webSocketConnection;
        private RestaurantManager restaurantManager;

        public SocketConnectionController(WebSocketConnection webSocketConnection, RestaurantManager restaurantManager)
        {
            this.webSocketConnection = webSocketConnection;
            this.restaurantManager = restaurantManager;
        }
        private void HandleMessage(string message)
        {
            Console.WriteLine("Message received: " + message);
            string answerMessage = "";
            if (message == "GET_MENU_REQ")
            {
                answerMessage = "GET_MENU_CFM\n" + restaurantManager.GetMenu().ToString();
            }
            webSocketConnection.SendAsync(answerMessage);
            Console.WriteLine("Message sent: " + answerMessage);
        }

    }
}

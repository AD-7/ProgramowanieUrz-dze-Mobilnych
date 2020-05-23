using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public class API
    {
        List<SocketConnectionController> socketConnections;
        private RestaurantManager restaurantManager;

        public API(RestaurantManager restaurantManager)
        {
            socketConnections = new List<SocketConnectionController>();
            this.restaurantManager = restaurantManager;
        }

        public void HandleConnectedClient(WebSocketConnection webSocketConnection)
        {

            socketConnections.Add(new SocketConnectionController(webSocketConnection, restaurantManager));
        }

       


    }
}

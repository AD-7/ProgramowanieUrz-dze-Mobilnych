using ServerLogic;
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
        private ReportSender reportSender;
        private AdvertSender advertSender;

        public API(RestaurantManager restaurantManager)
        {
            socketConnections = new List<SocketConnectionController>();
            this.restaurantManager = restaurantManager;
            this.reportSender = new ReportSender(restaurantManager, 30000);
            Task.Run(() => reportSender.SendReport());

            this.advertSender = new AdvertSender(restaurantManager, 10000);
            Task.Run(() => advertSender.SendReport());
        }

        public void HandleConnectedClient(WebSocketConnection webSocketConnection)
        {

            socketConnections.Add(new SocketConnectionController(webSocketConnection, restaurantManager, reportSender, advertSender));
        }




    }
}

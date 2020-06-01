﻿using ServerLogic;
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

        public API(RestaurantManager restaurantManager)
        {
            socketConnections = new List<SocketConnectionController>();
            this.restaurantManager = restaurantManager;
            this.reportSender = new ReportSender(restaurantManager, 5000);
            Task.Run(()=>reportSender.SendReport());
        }

        public void HandleConnectedClient(WebSocketConnection webSocketConnection)
        {

            socketConnections.Add(new SocketConnectionController(webSocketConnection, restaurantManager, reportSender));
        }

       


    }
}
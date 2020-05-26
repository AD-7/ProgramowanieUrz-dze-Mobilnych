using Logic;
using Logic.Serializer;
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
        private ClientReportSender clientReportSender;

        public SocketConnectionController(WebSocketConnection webSocketConnection, RestaurantManager restaurantManager, ReportSender reportSender)
        {
            this.webSocketConnection = webSocketConnection;
            this.webSocketConnection.onMessage = HandleMessage;
            this.restaurantManager = restaurantManager;
            this.clientReportSender = new ClientReportSender("", "", "", webSocketConnection);
            this.clientReportSender.Subscribe(reportSender);
        }
        private void HandleMessage(string message)
        {
            string receivedMessageType = "";
            string receivedMessage = "";
            string[] splitedMessage = message.Split('\n');

            if (splitedMessage.Length > 0)
            {
                receivedMessageType = splitedMessage[0];
            }
            for (int i = 1; i < splitedMessage.Length; i++)
            {
                receivedMessage += splitedMessage[i];
            }
            string[] paramss = receivedMessage.Split('$');

            Console.WriteLine("Message received: " + message);
            string answerMessage = "";
            if (receivedMessageType == "GET_MENU_REQ")
            {
                answerMessage = "GET_MENU_CFM\n" + Serializer.Serialize(restaurantManager.GetMenu());
            }
            else if (receivedMessageType == "GET_ACTIVE_ORDERS_REQ")
            {
                answerMessage = "GET_ACTIVE_ORDERS_CFM\n" + Serializer.Serialize(restaurantManager.GetActiveOrders());
            }
            else if (receivedMessageType == "GET_ACTIVE_DELIVERIES_REQ")
            {
                answerMessage = "GET_ACTIVE_DELIVERIES_CFM\n" + Serializer.Serialize(restaurantManager.GetActiveDeliveries());
            }
            else if (receivedMessageType == "GET_COMPLETED_DELIVERIES_REQ")
            {
                answerMessage = "GET_COMPLETED_DELIVERIES_CFM\n" + Serializer.Serialize(restaurantManager.GetCompletedDeliveries());
            }
            else if (receivedMessageType == "GET_COMPLETED_ORDERS_REQ")
            {
                answerMessage = "GET_COMPLETED_ORDERS_CFM\n" + Serializer.Serialize(restaurantManager.GetCompletedOrders());
            }

            else if (receivedMessageType == "GET_ALL_CLIENTS_REQ")
            {
                answerMessage = "GET_ALL_CLIENTS_CFM\n" + Serializer.Serialize(restaurantManager.GetAllClients());
            }
            else if (receivedMessageType == "GET_ORDER_BYID_REQ")
            {
                answerMessage = "GET_ORDER_BYID_CFM\n" + Serializer.Serialize(restaurantManager.GetOrderById(Convert.ToInt32(paramss[0])));
            }
            else if (receivedMessageType == "GET_DELIVERY_BYID_REQ")
            {
                answerMessage = "GET_DELIVERY_BYID_CFM\n" + Serializer.Serialize(restaurantManager.GetDeliveryById(Convert.ToInt32(paramss[0])));
            }
            else if (receivedMessageType == "CREATE_CLIENT_REQ")
            {
                answerMessage = "CREATE_CLIENT_CFM\n";
                restaurantManager.CreateClient(paramss[0], paramss[1], paramss[2], paramss[3], paramss[4]);
            }
            else if (receivedMessageType == "CREATE_DISH_REQ")
            {
                answerMessage = "CREATE_DISH_CFM\n";
                restaurantManager.CreateDish(paramss[0], paramss[1],null,(CategoryDTG)Convert.ToInt32( paramss[2]), Convert.ToDouble(paramss[3]));
            }
            else if(receivedMessageType == "CREATE_ORDER_REQ")
            {
                answerMessage = "CREATE_ORDER_CFM\n";

                List<string> dishNames = new List<string>();
                string[] dn = paramss[4].Split(',');
                foreach(string s in dn)
                {
                    dishNames.Add(s);
                }
                restaurantManager.CreateOrder(paramss[0], new DateTime(Convert.ToInt32(paramss[1]), Convert.ToInt32(paramss[2]), Convert.ToInt32(paramss[3])), Convert.ToBoolean(paramss[5]),
                                        dishNames, paramss[6], paramss[7], paramss[8],new DateTime(Convert.ToInt32(paramss[9]), Convert.ToInt32(paramss[10]), Convert.ToInt32(paramss[11])));

            }
            else if(receivedMessageType == "COMPLETE_ORDER_REQ")
            {
                answerMessage = "COMPLETE_ORDER_CFM\n";
                restaurantManager.CompleteOrder(Convert.ToInt32(paramss[0]));
            }
            else if (receivedMessageType == "COMPLETE_DELIVERY_REQ")
            {
                answerMessage = "COMPLETE_DELIVERY_CFM\n";
                restaurantManager.CompleteDelivery(Convert.ToInt32(paramss[0]));
            }




            if (answerMessage != "")
                webSocketConnection.SendAsync(answerMessage);
            Console.WriteLine("Message sent: " + answerMessage);
        }

    }
}

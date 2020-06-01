using Communication;

using Logic;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
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
            CommunicationType received = Deserializer.Deserialize(message);
            MESSAGE_TYPE receivedMessageType = received.MessageType;
            string receivedMessage = received.Message;
            string[] paramss = received.Parameters.ToArray();

            Console.WriteLine("Message received: " + message);
            CommunicationType answerMessage = new CommunicationType();
            if (receivedMessageType == MESSAGE_TYPE.GET_MENU_REQ)
            {
                answerMessage.MessageType = MESSAGE_TYPE.GET_MENU_CFM;
                answerMessage.Message = Serializer.Serialize(restaurantManager.GetMenu());
            }
            else if (receivedMessageType == MESSAGE_TYPE.GET_ACTIVE_ORDERS_REQ)
            {
                answerMessage.MessageType = MESSAGE_TYPE.GET_ACTIVE_ORDERS_CFM;
                answerMessage.Message = Serializer.Serialize(restaurantManager.GetActiveOrders());
            }
            else if (receivedMessageType == MESSAGE_TYPE.GET_ACTIVE_DELIVERIES_REQ)
            {
                answerMessage.MessageType = MESSAGE_TYPE.GET_ACTIVE_DELIVERIES_CFM;
                answerMessage.Message = Serializer.Serialize(restaurantManager.GetActiveDeliveries());
            }
            else if (receivedMessageType == MESSAGE_TYPE.GET_COMPLETED_DELIVERIES_REQ)
            {
                answerMessage.MessageType = MESSAGE_TYPE.GET_COMPLETED_DELIVERIES_CFM;
                answerMessage.Message = Serializer.Serialize(restaurantManager.GetCompletedDeliveries());
            }
            else if (receivedMessageType == MESSAGE_TYPE.GET_COMPLETED_ORDERS_REQ)
            {
                answerMessage.MessageType = MESSAGE_TYPE.GET_COMPLETED_ORDERS_CFM;
                answerMessage.Message = Serializer.Serialize(restaurantManager.GetCompletedOrders());
            }

            else if (receivedMessageType == MESSAGE_TYPE.GET_ALL_CLIENTS_REQ)
            {
                answerMessage.MessageType = MESSAGE_TYPE.GET_ALL_CLIENTS_CFM;
                answerMessage.Message = Serializer.Serialize(restaurantManager.GetAllClients());
            }
            else if (receivedMessageType == MESSAGE_TYPE.GET_ORDER_BYID_REQ)
            {
                answerMessage.MessageType = MESSAGE_TYPE.GET_ORDER_BYID_CFM;
                answerMessage.Message = Serializer.Serialize(restaurantManager.GetOrderById(Convert.ToInt32(paramss[0])));
            }
            else if (receivedMessageType == MESSAGE_TYPE.GET_DELIVERY_BYID_REQ)
            {
                answerMessage.MessageType = MESSAGE_TYPE.GET_DELIVERY_BYID_CFM;
                answerMessage.Message =  Serializer.Serialize(restaurantManager.GetDeliveryById(Convert.ToInt32(paramss[0])));
            }
            else if (receivedMessageType == MESSAGE_TYPE.CREATE_CLIENT_REQ)
            {
                answerMessage.MessageType = MESSAGE_TYPE.CREATE_CLIENT_CFM;
                restaurantManager.CreateClient(paramss[0], paramss[1], paramss[2], paramss[3], paramss[4]);
            }
            else if (receivedMessageType == MESSAGE_TYPE.CREATE_DISH_REQ)
            {
                answerMessage.MessageType = MESSAGE_TYPE.CREATE_DISH_CFM;
                restaurantManager.CreateDish(paramss[0], paramss[1], null, (CategoryDTG)Convert.ToInt32(paramss[2]), Convert.ToDouble(paramss[3]));
            }
            else if (receivedMessageType == MESSAGE_TYPE.CREATE_ORDER_REQ)
            {
                answerMessage.MessageType = MESSAGE_TYPE.CREATE_ORDER_CFM;

                List<string> dishNames = new List<string>();
                string[] dn = paramss[4].Split(',');
                foreach (string s in dn)
                {
                    dishNames.Add(s);
                }
                restaurantManager.CreateOrder(paramss[0], new DateTime(Convert.ToInt32(paramss[1]), Convert.ToInt32(paramss[2]), Convert.ToInt32(paramss[3])), Convert.ToBoolean(paramss[5]),
                                        dishNames, paramss[6], paramss[7], paramss[8], new DateTime(Convert.ToInt32(paramss[9]), Convert.ToInt32(paramss[10]), Convert.ToInt32(paramss[11])));

            }
            else if (receivedMessageType == MESSAGE_TYPE.COMPLETE_ORDER_REQ)
            {
                answerMessage.MessageType = MESSAGE_TYPE.COMPLETE_ORDER_CFM;
                restaurantManager.CompleteOrder(Convert.ToInt32(paramss[0]));
            }
            else if (receivedMessageType == MESSAGE_TYPE.COMPLETE_DELIVERY_REQ)
            {
                answerMessage.MessageType = MESSAGE_TYPE.COMPLETE_DELIVERY_CFM;
                restaurantManager.CompleteDelivery(Convert.ToInt32(paramss[0]));
            }




            if (answerMessage != null && answerMessage.MessageType != MESSAGE_TYPE.NONE)
                webSocketConnection.SendAsync(Communication.Serializer.SerializeCommunicationType( answerMessage));
            Console.WriteLine("Message sent: " + answerMessage);
        }

    }
}

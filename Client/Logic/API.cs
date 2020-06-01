using Dane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Logic.DeserializerClient;
using Communication;

namespace Logic
{
    public class API
    {

        private WebSocketConnection socketConnection;
        private string receivedMessageType;
        private string receivedMessage;
        private CommunicationType receivedAnswer;
        private const int SLEEP_TIME = 10;
        ReportSender reportSender;

        private void LogToConsole(string message)
        {
            Console.WriteLine(message);
        }

        public API(WebSocketConnection socketConnection)
        {
            this.reportSender = new ReportSender();
            this.socketConnection = socketConnection;
            this.socketConnection.onMessage = HandleMessage;
        }

        public ReportSender GetReportSender()
        {
            return reportSender;
        }

        public API()
        {

        }

        private void HandleMessage(string message)
        {

            receivedAnswer = Communication.Deserializer.Deserialize(message);

            if (receivedAnswer.MessageType == MESSAGE_TYPE.SEND_REPORT_CFM)
            {
                reportSender.SendReport(receivedAnswer.Message);
            }

         
        }

        private void SendRequestMessage(MESSAGE_TYPE messageType, List<string> value = null)
        {
            // value is a parameters separated by $ 
            CommunicationType cmd = new CommunicationType(messageType, "", value);
            
            switch (messageType)
            {
                case MESSAGE_TYPE.GET_MENU_REQ:
                    socketConnection.SendAsync(Communication.Serializer.SerializeCommunicationType(cmd));
                    break;
                case MESSAGE_TYPE.GET_ACTIVE_ORDERS_REQ:
                    socketConnection.SendAsync(Communication.Serializer.SerializeCommunicationType(cmd));
                    break;
                case MESSAGE_TYPE.GET_COMPLETED_ORDERS_REQ:
                    socketConnection.SendAsync(Communication.Serializer.SerializeCommunicationType(cmd));
                    break;
                case MESSAGE_TYPE.GET_ACTIVE_DELIVERIES_REQ:
                    socketConnection.SendAsync(Communication.Serializer.SerializeCommunicationType(cmd));
                    break;
                case MESSAGE_TYPE.GET_COMPLETED_DELIVERIES_REQ:
                    socketConnection.SendAsync(Communication.Serializer.SerializeCommunicationType(cmd));
                    break;
                case MESSAGE_TYPE.GET_ALL_CLIENTS_REQ:
                    socketConnection.SendAsync(Communication.Serializer.SerializeCommunicationType(cmd));
                    break;
                case MESSAGE_TYPE.GET_ORDER_BYID_REQ:
                    socketConnection.SendAsync(Communication.Serializer.SerializeCommunicationType(cmd));
                    break;
                case MESSAGE_TYPE.GET_DELIVERY_BYID_REQ:
                    socketConnection.SendAsync(Communication.Serializer.SerializeCommunicationType(cmd));
                    break;
                case MESSAGE_TYPE.CREATE_CLIENT_REQ:
                    socketConnection.SendAsync(Communication.Serializer.SerializeCommunicationType(cmd));
                    break;
                case MESSAGE_TYPE.CREATE_DISH_REQ:
                    socketConnection.SendAsync(Communication.Serializer.SerializeCommunicationType(cmd));
                    break;
                case MESSAGE_TYPE.CREATE_ORDER_REQ:
                    socketConnection.SendAsync(Communication.Serializer.SerializeCommunicationType(cmd));
                    break;
                case MESSAGE_TYPE.COMPLETE_ORDER_REQ:
                    socketConnection.SendAsync(Communication.Serializer.SerializeCommunicationType(cmd));
                    break;
                case MESSAGE_TYPE.COMPLETE_DELIVERY_REQ:
                    socketConnection.SendAsync(Communication.Serializer.SerializeCommunicationType(cmd));
                    break;


            }
        }

        public void AddDishToMenu(string name, string description, List<Ingredient> ingredientss, int category, double price)
        {
            Category cat = (Category)category;
            List<string> value = new List<string>();
            value.Add(name);
            value.Add(description);
            value.Add(Convert.ToInt32(cat).ToString());
            value.Add(Convert.ToString(price));
            SendRequestMessage(MESSAGE_TYPE.CREATE_DISH_REQ, value);
            while (receivedAnswer.MessageType != MESSAGE_TYPE.CREATE_DISH_CFM)
            {
                Thread.Sleep(SLEEP_TIME);
            }
        }


        public void CreateClient(string name, string phoneNumber, Address address)
        {
            List<string> value = new List<string>();
            value.Add(name);
            value.Add(phoneNumber);
            value.Add(address.Street);
            value.Add(address.Number);
            value.Add(address.PostalCode);

            SendRequestMessage(MESSAGE_TYPE.CREATE_CLIENT_REQ, value);
            while (receivedAnswer.MessageType != MESSAGE_TYPE.CREATE_CLIENT_CFM)
            {
                Thread.Sleep(SLEEP_TIME);
            }

        }

        public List<DishDTG> GetMenu()
        {
            SendRequestMessage(MESSAGE_TYPE.GET_MENU_REQ);

            while (receivedAnswer.MessageType != MESSAGE_TYPE.GET_MENU_CFM)
            {

                Thread.Sleep(SLEEP_TIME);
            }
            //Deserialize receivedMessage
            List<DishDTG> menu = DeserializerClient.Deserializer.Deserialize_Menu(receivedAnswer.Message);


            return menu;

        }
        public List<OrderDTG> GetActiveOrders()
        {
            SendRequestMessage(MESSAGE_TYPE.GET_ACTIVE_ORDERS_REQ);
            while (receivedAnswer.MessageType != MESSAGE_TYPE.GET_ACTIVE_ORDERS_CFM)
            {
                Thread.Sleep(SLEEP_TIME);
            }
            //Deserialize receivedMessage
            List<OrderDTG> orders = DeserializerClient.Deserializer.Deserialize_Orders(receivedAnswer.Message);
            return orders;
        }

        public List<OrderDTG> GetActiveDeliveries()
        {
            SendRequestMessage(MESSAGE_TYPE.GET_ACTIVE_DELIVERIES_REQ);
            while (receivedAnswer.MessageType != MESSAGE_TYPE.GET_ACTIVE_DELIVERIES_CFM)
            {
                Thread.Sleep(SLEEP_TIME);
            }
            List<OrderDTG> orders = DeserializerClient.Deserializer.Deserialize_Orders(receivedAnswer.Message);
            return orders;
        }

        public Client GetClientByName(string clientName)
        {
            throw new NotImplementedException();
        }

        public Dish GetDishByName(string dishName)
        {
            throw new NotImplementedException();
        }

        public List<OrderDTG> GetCompletedDeliveries()
        {
            SendRequestMessage(MESSAGE_TYPE.GET_COMPLETED_DELIVERIES_REQ);
            while (receivedAnswer.MessageType != MESSAGE_TYPE.GET_COMPLETED_DELIVERIES_CFM)
            {
                Thread.Sleep(SLEEP_TIME);
            }
            List<OrderDTG> orders = DeserializerClient.Deserializer.Deserialize_Orders(receivedAnswer.Message);
            return orders;
        }

        public void CreateDelivery(int currentOrderIndex, Client client, DateTime orderDate, List<Dish> dishes, bool delivery, Address deliveryAddress, DateTime deliveryEndTime)
        {
            throw new NotImplementedException();
        }

        public void CreateOrder(int currentOrderIndex, string clientName, DateTime orderDate, string dishes, bool delivery, Address deliveryAddress, DateTime deliveryEndTime)
        {
            List<string> value = new List<string>();
            value.Add(clientName);
            value.Add(orderDate.Year.ToString());
            value.Add(orderDate.Month.ToString());
            value.Add(orderDate.Day.ToString());
            value.Add(dishes);
            value.Add(delivery.ToString());
            value.Add(deliveryAddress.Street);
            value.Add(deliveryAddress.Number);
            value.Add(deliveryAddress.PostalCode);
            value.Add(deliveryEndTime.Year.ToString());
            value.Add(deliveryEndTime.Month.ToString());
            value.Add(deliveryEndTime.Day.ToString());

            SendRequestMessage(MESSAGE_TYPE.CREATE_ORDER_REQ, value);
            while (receivedAnswer.MessageType != MESSAGE_TYPE.CREATE_ORDER_CFM)
            {
                Thread.Sleep(SLEEP_TIME);
            }



        }

        public List<OrderDTG> GetCompletedOrders()
        {
            SendRequestMessage(MESSAGE_TYPE.GET_COMPLETED_ORDERS_REQ);
            while (receivedAnswer.MessageType != MESSAGE_TYPE.GET_COMPLETED_ORDERS_CFM)
            {
                Thread.Sleep(SLEEP_TIME);
            }
            List<OrderDTG> orders = DeserializerClient.Deserializer.Deserialize_Orders(receivedAnswer.Message);
            return orders;
        }

        public void CompleteOrder(int id)
        {
            List<string> cmd = new List<string>();
            cmd.Add(id.ToString());
            SendRequestMessage(MESSAGE_TYPE.COMPLETE_ORDER_REQ,cmd );
            while (receivedAnswer.MessageType != MESSAGE_TYPE.COMPLETE_ORDER_CFM)
            {
                Thread.Sleep(SLEEP_TIME);
            }

        }

        public void CompleteDelivery(int id)
        {
            List<string> cmd = new List<string>();
            cmd.Add(id.ToString());
            SendRequestMessage(MESSAGE_TYPE.COMPLETE_DELIVERY_REQ, cmd);
            while (receivedAnswer.MessageType != MESSAGE_TYPE.COMPLETE_DELIVERY_CFM)
            {
                Thread.Sleep(SLEEP_TIME);
            }
        }

        public Dish GetDishById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ClientDTG> GetAllClients()
        {
            SendRequestMessage(MESSAGE_TYPE.GET_ALL_CLIENTS_REQ);
            while (receivedAnswer.MessageType != MESSAGE_TYPE.GET_ALL_CLIENTS_CFM)
            {
                Thread.Sleep(SLEEP_TIME);
            }
            List<ClientDTG> clients = DeserializerClient.Deserializer.Deserialize_Clients(receivedAnswer.Message);
            return clients;
        }

        public OrderDTG GetActiveOrderById(int id)
        {
            List<string> cmd = new List<string>();
            cmd.Add(id.ToString());
            SendRequestMessage(MESSAGE_TYPE.GET_ORDER_BYID_REQ, cmd);
            while (receivedAnswer.MessageType != MESSAGE_TYPE.GET_ORDER_BYID_CFM)
            {
                Thread.Sleep(SLEEP_TIME);
            }

            OrderDTG order = DeserializerClient.Deserializer.Deserialize_Order(receivedAnswer.Message);
            return order;
        }

        public OrderDTG GetDeliveryById(int id)
        {
            List<string> cmd = new List<string>();
            cmd.Add(id.ToString());
            SendRequestMessage(MESSAGE_TYPE.GET_DELIVERY_BYID_REQ, cmd);
            while (receivedAnswer.MessageType != MESSAGE_TYPE.GET_DELIVERY_BYID_CFM)
            {
                Thread.Sleep(SLEEP_TIME);
            }

            OrderDTG order = DeserializerClient.Deserializer.Deserialize_Order(receivedAnswer.Message);
            return order;
        }
    }
}

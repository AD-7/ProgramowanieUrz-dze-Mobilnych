using Dane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logic
{
    public class API
    {
        public enum MESSAGE_TYPE { GET_MENU_REQ, GET_ACTIVE_ORDERS_REQ, GET_COMPLETED_ORDERS_REQ, GET_ACTIVE_DELIVERIES_REQ, GET_COMPLETED_DELIVERIES_REQ,
            GET_ALL_CLIENTS_REQ, GET_ORDER_BYID_REQ, GET_DELIVERY_BYID_REQ, CREATE_CLIENT_REQ, CREATE_DISH_REQ, CREATE_ORDER_REQ, COMPLETE_ORDER_REQ, COMPLETE_DELIVERY_REQ,

            GET_MENU_CFM, GET_ACTIVE_ORDERS_CFM, GET_COMPLETED_ORDERS_CFM, GET_ACTIVE_DELIVERIES_CFM, GET_COMPLETED_DELIVERIES_CFM, GET_ALL_CLIENTS_CFM,
            GET_ORDER_BYID_CFM, GET_DELIVERY_BYID_CFM, CREATE_CLIENT_CFM, CREATE_DISH_CFM, CREATE_ORDER_CFM, COMPLETE_ORDER_CFM, COMPLETE_DELIVERY_CFM
        }
        private WebSocketConnection socketConnection;
        private string receivedMessageType;
        private string receivedMessage;
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
            receivedMessageType = "";
            receivedMessage = "";
            string [] splitedMessage = message.Split('\n');
            if(splitedMessage.Length > 1)
            {
                receivedMessageType = splitedMessage[0];
            }
            for (int i = 1; i < splitedMessage.Length; i++)
            {
                receivedMessage += splitedMessage[i] ;
            }
            
            if (receivedMessageType == "SEND_REPORT_CFM")
            {
                reportSender.SendReport(receivedMessage);
            }
        }

        private void SendRequestMessage(MESSAGE_TYPE messageType, string value = "")
        {
            // value is a parameters separated by $ 

            switch (messageType)
            {
                case MESSAGE_TYPE.GET_MENU_REQ:
                    socketConnection.SendAsync("GET_MENU_REQ");
                    break;
                case MESSAGE_TYPE.GET_ACTIVE_ORDERS_REQ:
                    socketConnection.SendAsync("GET_ACTIVE_ORDERS_REQ");
                    break;
                case MESSAGE_TYPE.GET_COMPLETED_ORDERS_REQ:
                    socketConnection.SendAsync("GET_COMPLETED_ORDERS_REQ");
                    break;
                case MESSAGE_TYPE.GET_ACTIVE_DELIVERIES_REQ:
                    socketConnection.SendAsync("GET_ACTIVE_DELIVERIES_REQ");
                    break;
                case MESSAGE_TYPE.GET_COMPLETED_DELIVERIES_REQ:
                    socketConnection.SendAsync("GET_COMPLETED_DELIVERIES_REQ");
                    break;
                case MESSAGE_TYPE.GET_ALL_CLIENTS_REQ:
                    socketConnection.SendAsync("GET_ALL_CLIENTS_REQ");
                    break;
                case MESSAGE_TYPE.GET_ORDER_BYID_REQ:
                      socketConnection.SendAsync("GET_ORDER_BYID_REQ\n" + value);
                    break;
                case MESSAGE_TYPE.GET_DELIVERY_BYID_REQ:
                    socketConnection.SendAsync("GET_DELIVERY_BYID_REQ\n" + value);
                    break;
                case MESSAGE_TYPE.CREATE_CLIENT_REQ:
                    socketConnection.SendAsync("CREATE_CLIENT_REQ\n" + value);
                    break;
                case MESSAGE_TYPE.CREATE_DISH_REQ:
                    socketConnection.SendAsync("CREATE_DISH_REQ\n" + value);
                    break;
                case MESSAGE_TYPE.CREATE_ORDER_REQ:
                    socketConnection.SendAsync("CREATE_ORDER_REQ\n" + value);
                    break;
                case MESSAGE_TYPE.COMPLETE_ORDER_REQ:
                    socketConnection.SendAsync("COMPLETE_ORDER_REQ\n" + value);
                    break;
                case MESSAGE_TYPE.COMPLETE_DELIVERY_REQ:
                    socketConnection.SendAsync("COMPLETE_DELIVERY_REQ\n" + value);
                    break;


            }
        }

        public void AddDishToMenu(string name, string description, List<Ingredient> ingredientss, int category, double price)
        {
            Category cat = (Category)category;
            string value = name + "$" + description + "$" + Convert.ToInt32(cat).ToString() + "$" + Convert.ToString(price);
            SendRequestMessage(MESSAGE_TYPE.CREATE_DISH_REQ,value);
            while (receivedMessageType != "CREATE_DISH_CFM")
            {
                Thread.Sleep(SLEEP_TIME);
            }
        }

        
        public void CreateClient(string name, string phoneNumber, Address address)
        {
            string value = name + "$" + phoneNumber + "$" + address.Street + "$" + address.Number + "$" + address.PostalCode;

            SendRequestMessage(MESSAGE_TYPE.CREATE_CLIENT_REQ, value);
            while (receivedMessageType != "CREATE_CLIENT_CFM")
            {
                Thread.Sleep(SLEEP_TIME);
            }

        }

        public List<DishDTG> GetMenu()
        {
            SendRequestMessage(MESSAGE_TYPE.GET_MENU_REQ);
        
            while(receivedMessageType != "GET_MENU_CFM")
            {

                Thread.Sleep(SLEEP_TIME);        
            }
            //Deserialize receivedMessage
            List<DishDTG> menu = Deserializer.Deserialize_Menu(receivedMessage);

          
            return menu;
            
        }
        public List<OrderDTG> GetActiveOrders()
        {
            SendRequestMessage(MESSAGE_TYPE.GET_ACTIVE_ORDERS_REQ);
            while (receivedMessageType != "GET_ACTIVE_ORDERS_CFM")
            {
                Thread.Sleep(SLEEP_TIME);
            }
            //Deserialize receivedMessage
            List<OrderDTG> orders = Deserializer.Deserialize_Orders(receivedMessage);
            return orders;
        }

        public List<OrderDTG> GetActiveDeliveries()
        {
            SendRequestMessage(MESSAGE_TYPE.GET_ACTIVE_DELIVERIES_REQ);
            while (receivedMessageType != "GET_ACTIVE_DELIVERIES_CFM")
            {
                Thread.Sleep(SLEEP_TIME);
            }
            List<OrderDTG> orders = Deserializer.Deserialize_Orders(receivedMessage);
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
            while (receivedMessageType != "GET_COMPLETED_DELIVERIES_CFM")
            {
                Thread.Sleep(SLEEP_TIME);
            }
            List<OrderDTG> orders = Deserializer.Deserialize_Orders(receivedMessage);
            return orders;
        }

        public void CreateDelivery(int currentOrderIndex, Client client, DateTime orderDate, List<Dish> dishes, bool delivery, Address deliveryAddress, DateTime deliveryEndTime)
        {
            throw new NotImplementedException();
        }

        public void CreateOrder(int currentOrderIndex, string clientName, DateTime orderDate, string dishes, bool delivery, Address deliveryAddress, DateTime deliveryEndTime)
        {
            string value = clientName + "$" + orderDate.Year + "$" + orderDate.Month + "$" + orderDate.Day + "$" + dishes + "$" + delivery.ToString() + "$" + deliveryAddress.Street + "$" +
                             deliveryAddress.Number + "$" + deliveryAddress.PostalCode + "$" + deliveryEndTime.Year + "$" + deliveryEndTime.Month + "$" + deliveryEndTime.Day;

            SendRequestMessage(MESSAGE_TYPE.CREATE_ORDER_REQ, value);
            while(receivedMessageType != "CREATE_ORDER_CFM")
            {
                Thread.Sleep(SLEEP_TIME);
            }



        }

        public List<OrderDTG> GetCompletedOrders()
        {
            SendRequestMessage(MESSAGE_TYPE.GET_COMPLETED_ORDERS_REQ);
            while (receivedMessageType != "GET_COMPLETED_ORDERS_CFM")
            {
                Thread.Sleep(SLEEP_TIME);
            }
            List<OrderDTG> orders = Deserializer.Deserialize_Orders(receivedMessage);
            return orders;
        }

        public void CompleteOrder(int id)
        {
            SendRequestMessage(MESSAGE_TYPE.COMPLETE_ORDER_REQ, id.ToString());
            while(receivedMessageType != "COMPLETE_ORDER_CFM")
            {
                Thread.Sleep(SLEEP_TIME);
            }
            
        }

        public void CompleteDelivery(int id)
        {
            SendRequestMessage(MESSAGE_TYPE.COMPLETE_DELIVERY_REQ, id.ToString());
            while (receivedMessageType != "COMPLETE_DELIVERY_CFM")
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
            while (receivedMessageType != "GET_ALL_CLIENTS_CFM")
            {
                Thread.Sleep(SLEEP_TIME);
            }
            List<ClientDTG> clients = Deserializer.Deserialize_Clients(receivedMessage);
            return clients;
        }

        public OrderDTG GetActiveOrderById(int id)
        {
            SendRequestMessage(MESSAGE_TYPE.GET_ORDER_BYID_REQ,id.ToString());
            while (receivedMessageType != "GET_ORDER_BYID_CFM")
            {
                Thread.Sleep(SLEEP_TIME);
            }

            OrderDTG order = Deserializer.Deserialize_Order(receivedMessage);
            return order;
        }

        public OrderDTG GetDeliveryById(int id)
        {
            SendRequestMessage(MESSAGE_TYPE.GET_DELIVERY_BYID_REQ,id.ToString());
            while (receivedMessageType != "GET_DELIVERY_BYID_CFM")
            {
                Thread.Sleep(SLEEP_TIME);
            }

            OrderDTG order = Deserializer.Deserialize_Order(receivedMessage);
            return order;
        }
    }
}

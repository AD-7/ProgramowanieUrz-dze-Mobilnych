using Dane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class API
    {
        public enum MESSAGE_TYPE { GET_MENU_REQ, GET_ACTIVE_ORDERS_REQ, GET_COMPLETED_ORDERS_REQ, GET_ACTIVE_DELIVERIES_REQ, GET_COMPLETED_DELIVERIES_REQ,
            GET_MENU_CFM, GET_ACTIVE_ORDERS_CFM, GET_COMPLETED_ORDERS_CFM, GET_ACTIVE_DELIVERIES_CFM, GET_COMPLETED_DELIVERIES_CFM
        }
        private WebSocketConnection socketConnection;
        private string receivedMessageType;
        private string receivedMessage;

        private void LogToConsole(string message)
        {
            Console.WriteLine(message);
        }

        public API(WebSocketConnection socketConnection)
        {

            this.socketConnection = socketConnection;
            this.socketConnection.onMessage = HandleMessage;
        }

        public API()
        {
           
        }

        private void HandleMessage(string message)
        {
            string [] splitedMessage = message.Split('\n');
            if(splitedMessage.Length > 1)
            {
                receivedMessageType = splitedMessage[0];
            }
            for (int i = 1; i < splitedMessage.Length; i++)
            {
                receivedMessage += splitedMessage[i] + "/n";
            }
        }

        private void SendRequestMessage(MESSAGE_TYPE messageType)
        {
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
            }
        }

        public void AddDishToMenu(string name, string description, List<Ingredient> ingredientss, int category, double price)
        {
            Category cat = (Category)category;
            SendRequestMessage(MESSAGE_TYPE.GET_MENU_REQ);
            throw new NotImplementedException();
        }

        
        public void CreateClient(string name, string phoneNumber, Address address)
        {
            throw new NotImplementedException();
        }

        public Menu GetMenu()
        {
            SendRequestMessage(MESSAGE_TYPE.GET_MENU_REQ);
            while(receivedMessageType != "GET_MENU_CFM")
            {
                Thread.Sleep(100);
            }
            //Deserialize receivedMessage
            return null;
            
        }
        public List<Order> GetActiveOrders()
        {
            SendRequestMessage(MESSAGE_TYPE.GET_ACTIVE_ORDERS_REQ);
            while (receivedMessageType != "GET_ACTIVE_ORDERS_CFM")
            {
                Thread.Sleep(100);
            }
            //Deserialize receivedMessage
            return null;
        }

        public List<Order> GetActiveDeliveries()
        {
            SendRequestMessage(MESSAGE_TYPE.GET_ACTIVE_DELIVERIES_REQ);
            while (receivedMessageType != "GET_ACTIVE_DELIVERIES_CFM")
            {
                Thread.Sleep(100);
            }
            return null;//MapperToDTG.OrderDTGs(deliveryManager.DeliveryOrders);
        }

        public Client GetClientByName(string clientName)
        {
            throw new NotImplementedException();
        }

        public Dish GetDishByName(string dishName)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetCompletedDeliveries()
        {
            SendRequestMessage(MESSAGE_TYPE.GET_COMPLETED_DELIVERIES_REQ);
            while (receivedMessageType != "GET_COMPLETED_DELIVERIES_CFM")
            {
                Thread.Sleep(100);
            }
            return null;// MapperToDTG.OrderDTGs(deliveryManager.DeliveryCompleted);
        }

        public void CreateDelivery(int currentOrderIndex, Client client, DateTime orderDate, List<Dish> dishes, bool delivery, Address deliveryAddress, DateTime deliveryEndTime)
        {
            throw new NotImplementedException();
        }

        public void CreateOrder(int currentOrderIndex, Client client, DateTime orderDate, List<Dish> dishes, bool delivery, Address deliveryAddress, DateTime deliveryEndTime)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetCompletedOrders()
        {
            SendRequestMessage(MESSAGE_TYPE.GET_COMPLETED_ORDERS_REQ);
            while (receivedMessageType != "GET_COMPLETED_ORDERS_REQ")
            {
                Thread.Sleep(100);
            }
            return null;//MapperToDTG.OrderDTGs(orderManager.CompletedOrders);
        }

        public void CompleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public void CompleteDelivery(int id)
        {
            throw new NotImplementedException();
        }

        public Dish GetDishById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Client> GetAllClients()
        {
            throw new NotImplementedException();
        }

        public Order GetActiveOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public Order GetDeliveryById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

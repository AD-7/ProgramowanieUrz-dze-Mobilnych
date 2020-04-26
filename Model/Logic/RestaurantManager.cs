using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class RestaurantManager
    {

        private ClientManager clientManager { get; set; }
        private MenuManager menuManager { get; set; }
        private DeliveryManager deliveryManager { get; set; }
        private OrderManager orderManager { get; set; }

        private int currentOrderIndex;

        public RestaurantManager()
        {
            clientManager = new ClientManager();
            orderManager = new OrderManager();
            menuManager = new MenuManager();
            deliveryManager = new DeliveryManager();
            currentOrderIndex = 0;
        }


        public void CreateClient(string name, string phoneNumber, Address adress)
        {
            clientManager.CreateClient(name, phoneNumber, adress);
        }

        public void CreateDish(string name, string description, List<Ingredient> ingredients, Category category, double price)
        {
            menuManager.AddDishToMenu(name, description, ingredients, category, price);
        }

        public void CreateOrder(int currentOrderIndex, Client client, DateTime orderDate, bool delivery, Address deliveryAddress, DateTime deliveryEndTime)
        {
            if (delivery)
            {
                deliveryManager.CreateOrder(currentOrderIndex, client, orderDate, delivery, deliveryAddress, deliveryEndTime);
            }
            else
            {
                orderManager.CreateOrder(currentOrderIndex, client, orderDate, delivery, deliveryAddress, deliveryEndTime);
            }
            currentOrderIndex++;
        }

        public void CompleteOrder(int Id)
        {
            orderManager.CompleteOrder(Id);
        }

        public void CompleteDelivery(int Id)
        {
            deliveryManager.CompleteOrder(Id);
        }

        public List<Dish> GetMenu()
        {
            return menuManager.GetMenu();
        }

        public List<Order> GetActiveOrders()
        {
            return orderManager.activeOrders;
        }

        public List<Order> GetActiveDeliveries()
        {
            return deliveryManager.deliveryOrders;
        }

        //TO DO : wysyłanie raportu niezależnie od użytkownika
        public double IncomeReport(DateTime from, DateTime to)
        {
            double income = 0.0;
            foreach (Order order in orderManager.completedOrders)
            {
                if (order.OrderDate > from && order.OrderDate < to)
                {
                    income += order.TotalPrice;
                }
            }

            foreach (Order order in deliveryManager.deliveryCompleted)
            {
                if (order.OrderDate > from && order.OrderDate < to)
                {
                    income += order.TotalPrice;
                }
            }
            return income;
        }



    }
}

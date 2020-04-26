using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class RestaurantManager
    {
        private readonly object criticalSection = new object();
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
            lock(criticalSection)
            {
                clientManager.CreateClient(name, phoneNumber, adress);
            }            
        }

        public void CreateDish(string name, string description, List<Ingredient> ingredients, Category category, double price)
        {
            lock(criticalSection)
            {
                menuManager.AddDishToMenu(name, description, ingredients, category, price);
            }           
        }

        public void CreateOrder(int currentOrderIndex, Client client, DateTime orderDate, bool delivery, Address deliveryAddress, DateTime deliveryEndTime)
        {
            lock(criticalSection)
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
           
        }

        public void CompleteOrder(int Id)
        {
            lock(criticalSection)
            {
                orderManager.CompleteOrder(Id);
            }
           
        }

        public void CompleteDelivery(int Id)
        {
            lock(criticalSection)
            {
                deliveryManager.CompleteOrder(Id);
            }           
        }

        public List<Dish> GetMenu()
        {
            return menuManager.GetMenu();
        }

        public List<Order> GetActiveOrders()
        {
            return orderManager.ActiveOrders;
        }

        public List<Order> GetActiveDeliveries()
        {
            return deliveryManager.DeliveryOrders;
        }

        //TO DO : wysyłanie raportu niezależnie od użytkownika
        public double IncomeReport(DateTime from, DateTime to)
        {
            lock(criticalSection)
            {
                double income = 0.0;
                foreach (Order order in orderManager.CompletedOrders)
                {
                    if (order.OrderDate > from && order.OrderDate < to)
                    {
                        income += order.TotalPrice;
                    }
                }

                foreach (Order order in deliveryManager.DeliveryCompleted)
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
}

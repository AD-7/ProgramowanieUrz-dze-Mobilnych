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

        public void AddSampleData()
        {
            this.CreateDish("testDish", "s", new List<Ingredient>(), Category.alcohol, 15.50);
            this.CreateDish("testDish1", "s", new List<Ingredient>(), Category.alcohol, 12.50);
            this.CreateDish("testDish2", "s", new List<Ingredient>(), Category.alcohol, 8.50);
            this.CreateDish("testDish3", "s", new List<Ingredient>(), Category.alcohol, 5.50);
            this.CreateClient("Imie Nazwisko", "606060606", "", "", "");
        }


        public void CreateClient(string name, string phoneNumber, string street, string number, string postalCode)
        {
            lock (criticalSection)
            {
                Address address = new Address(street, number, postalCode);
                clientManager.CreateClient(name, phoneNumber, address);
            }
        }

        public void CreateDish(string name, string description, List<Ingredient> ingredients, Category category, double price)
        {
            lock (criticalSection)
            {
                menuManager.AddDishToMenu(name, description, ingredients, category, price);
            }
        }

        public void CreateOrder(Client client, DateTime orderDate, List<Dish> dishes, bool delivery, Address deliveryAddress, DateTime deliveryEndTime)
        {
            lock (criticalSection)
            {
                if (delivery)
                {
                    deliveryManager.CreateOrder(currentOrderIndex, client, orderDate, dishes, delivery, deliveryAddress, deliveryEndTime);
                }
                else
                {
                    orderManager.CreateOrder(currentOrderIndex, client, orderDate, dishes, delivery, deliveryAddress, deliveryEndTime);
                }
                currentOrderIndex++;
            }

        }

        public void CreateOrder(string clientName, DateTime orderDate, bool delivery, List<string> dishesNames, string street, string number, string postalCode, DateTime deliveryEndTime)
        {
            lock (criticalSection)
            {
                Client client = clientManager.GetClientByName(clientName);
                Address deliveryAddress = new Address(street, number, postalCode);
                List<Dish> dishes = new List<Dish>();
                foreach (string dishName in dishesNames)
                {
                    dishes.Add(menuManager.GetDishByName(dishName));
                }

                if (delivery)
                {
                    deliveryManager.CreateOrder(currentOrderIndex, client, orderDate, dishes, delivery, deliveryAddress, deliveryEndTime);
                }
                else
                {
                    orderManager.CreateOrder(currentOrderIndex, client, orderDate, dishes, delivery, deliveryAddress, deliveryEndTime);
                }
                currentOrderIndex++;
            }

        }

        public void CompleteOrder(int Id)
        {
            lock (criticalSection)
            {
                orderManager.CompleteOrder(Id);
            }

        }

        public void CompleteDelivery(int Id)
        {
            lock (criticalSection)
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
        public List<Order> GetCompletedDeliveries()
        {
            return deliveryManager.DeliveryCompleted;
        }
        public List<Order> GetCompletedOrders()
        {
            return orderManager.CompletedOrders;
        }

        public Dish GetDishById(int Id)
        {
            return menuManager.GetDishById(Id);
        }
        public List<Client> GetAllClients()
        {
            return clientManager.Clients;
        }
        public Order GetOrderById(int Id)
        {
            return orderManager.GetActiveOrderById(Id);
        }
        public Order GetDeliveryById(int Id)
        {
            return deliveryManager.GetDeliveryById(Id);
        }
        //TO DO : wysyłanie raportu niezależnie od użytkownika
        public IncomeReport GenerateIncomeReport(DateTime from, DateTime to)
        {
            lock (criticalSection)
            {
                double income = 0.0;
                foreach (Order order in orderManager.CompletedOrders)
                {
                    if (order.CompleteOrderDate > from && order.CompleteOrderDate < to)
                    {
                        income += order.TotalPrice;
                    }
                }

                foreach (Order order in deliveryManager.DeliveryCompleted)
                {
                    if (order.CompleteOrderDate > from && order.CompleteOrderDate < to)
                    {
                        income += order.TotalPrice;
                    }
                }
                return new IncomeReport(income, from, to);
            }

        }



    }
}

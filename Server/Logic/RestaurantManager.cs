﻿using Dane;
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
            this.CreateDish("testDish", "s", new List<IngredientDTG>(), CategoryDTG.alcohol, 15.50);
            this.CreateDish("testDish1", "s", new List<IngredientDTG>(), CategoryDTG.alcohol, 12.50);
            this.CreateDish("testDish2", "s", new List<IngredientDTG>(), CategoryDTG.alcohol, 8.50);
            this.CreateDish("testDish3", "s", new List<IngredientDTG>(), CategoryDTG.alcohol, 5.50);
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

        public void CreateDish(string name, string description, List<IngredientDTG> ingredients, CategoryDTG category, double price)
        {
            lock (criticalSection)
            {
                
                List<Ingredient> ingredientss = new List<Ingredient>();
                if (ingredients != null)
                {
                    foreach (IngredientDTG dtg in ingredients)
                    {
                        ingredientss.Add(new Ingredient(new Product(dtg.Product.Id, dtg.Product.Name), dtg.Quantity));
                    }
                }
                menuManager.AddDishToMenu(name, description, ingredientss, category, price);
            }
        }

        public void CreateOrder(ClientDTG client, DateTime orderDate, List<DishDTG> dishes, bool delivery, AddressDTG deliveryAddress, DateTime deliveryEndTime)
        {
            lock (criticalSection)
            {
                Client tmp = new Client(client.Id, client.Name, client.PhoneNumber, new Address(client.Adress.Street, client.Adress.Number, client.Adress.PostalCode));
                if (delivery)
                {
                    deliveryManager.CreateOrder(currentOrderIndex, tmp, orderDate, dishes, delivery, new Address(deliveryAddress.Street,deliveryAddress.Number,deliveryAddress.PostalCode), deliveryEndTime);
                }
                else
                {
                    orderManager.CreateOrder(currentOrderIndex, tmp, orderDate, dishes, delivery, new Address(deliveryAddress.Street, deliveryAddress.Number, deliveryAddress.PostalCode), deliveryEndTime);
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
                List<DishDTG> dishes = new List<DishDTG>();
                
                foreach (string dishName in dishesNames)
                {
                    dishes.Add(MapperToDTG.DishDTG( menuManager.GetDishByName(dishName)));
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

        public List<DishDTG> GetMenu()
        {
            return MapperToDTG.DishDTGs( menuManager.GetMenu());
        }

        public List<OrderDTG> GetActiveOrders()
        {
            return MapperToDTG.OrderDTGs(orderManager.ActiveOrders);
        }

        public List<OrderDTG> GetActiveDeliveries()
        {
            return MapperToDTG.OrderDTGs(deliveryManager.DeliveryOrders);
        }
        public List<OrderDTG> GetCompletedDeliveries()
        {
            return MapperToDTG.OrderDTGs(deliveryManager.DeliveryCompleted);
        }
        public List<OrderDTG> GetCompletedOrders()
        {
            return MapperToDTG.OrderDTGs(orderManager.CompletedOrders);
        }

        public DishDTG GetDishById(int Id)
        {
            return MapperToDTG.DishDTG(menuManager.GetDishById(Id));
        }
        public List<ClientDTG> GetAllClients()
        {
            return MapperToDTG.ClientDTGs(clientManager.Clients);
        }
        public OrderDTG GetOrderById(int Id)
        {
            return MapperToDTG.OrderDTG(orderManager.GetActiveOrderById(Id));
        }
        public OrderDTG GetDeliveryById(int Id)
        {
            return MapperToDTG.OrderDTG(deliveryManager.GetDeliveryById(Id));
        }
       
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
using System;
using Logic;
using Presentation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Sockets;
using System.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace IntegrationTests
{   
    [TestClass]
    public class RestaurantManagerIntegrationTests
    {
        private RestaurantManager restaurantManager;
        [TestInitialize]
        public void TestInitialize()
        {
            TcpListener l = new TcpListener(IPAddress.Loopback, 0);
            l.Start();
            int port = ((IPEndPoint)l.LocalEndpoint).Port;
            l.Stop();
            string[] arg = { port.ToString() };
            Task.Run(() => Program.Main(arg));
            Thread.Sleep(2000);
            restaurantManager = new RestaurantManager(port);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Program.Stop();
        }

        [TestMethod]
        public void TestAddClient()
        {            
            restaurantManager.CreateClient("testName", "111222333", "Street", "1", "90-200");
            List<ClientDTG> clients = restaurantManager.GetAllClients();
            Assert.AreEqual(2, clients.Count, "Wrong clients number");
            Assert.AreEqual("testName", clients[1].Name, "Wrong client name");
            Assert.AreEqual("Street", clients[1].Adress.Street, "Wrong client street");
        }
        [TestMethod]
        public void TestAddDish()
        {

            restaurantManager.CreateDish("Chips", "testDishDescription", null, CategoryDTG.snack, 1.0);
            List<DishDTG> dishes = restaurantManager.GetMenu();
            Assert.AreEqual(5, dishes.Count, "Wrong clients number");
            Assert.AreEqual("Chips", dishes[4].Name, "Wrong dish name");
            Assert.AreEqual(CategoryDTG.snack, dishes[4].Category, "Wrong dish category");
        }

       

        [TestMethod]
        public void TestCreateOrder()
        {
            DateTime orderTime = DateTime.Now.Date;
            restaurantManager.CreateDish("Chips", "testDishDescription", null, CategoryDTG.snack, 1.0);
            restaurantManager.CreateClient("John Smith", "111222333", "Street", "1", "90-200");
            restaurantManager.CreateClient("Matthew Johnson", "111222333", "Street", "1", "90-200");
            List<string> dishesNames = new List<string>();
            dishesNames.Add("Chips");

            restaurantManager.CreateOrder("John Smith", DateTime.Now, false, dishesNames, "Street", "2", "00-000", DateTime.Now);
            List<OrderDTG> orders = restaurantManager.GetActiveOrders();
            Assert.AreEqual(1, orders.Count, "Wrong orders number");

            restaurantManager.CreateOrder("Matthew Johnson", DateTime.Now, true, dishesNames, "AnotherStreet", "5", "11-111", orderTime);
            List<OrderDTG> deliveries = restaurantManager.GetActiveDeliveries();
            Assert.AreEqual(1, deliveries.Count, "Wrong deliveries number");

            Assert.AreEqual("John Smith", orders[0].Client.Name, "Wrong order client name");
            Assert.AreEqual("Chips", orders[0].Dishes[0].Name, "Wrong dish name");

            Assert.AreEqual("Matthew Johnson", deliveries[0].Client.Name, "Wrong delivery client name");
            Assert.AreEqual(orderTime, deliveries[0].DeliveryEndTime, "Wrong delivery date");
        }

        [TestMethod]
        public void TestCompleteOrder()
        {
            DateTime orderTime = DateTime.Now.Date;
            restaurantManager.CreateDish("Chips", "testDishDescription", null, CategoryDTG.snack, 1.0);
            restaurantManager.CreateClient("John Smith", "111222333", "Street", "1", "90-200");
            restaurantManager.CreateClient("Matthew Johnson", "111222333", "Street", "1", "90-200");
            List<string> dishesNames = new List<string>();
            dishesNames.Add("Chips");

            restaurantManager.CreateOrder("John Smith", DateTime.Now, false, dishesNames, "Street", "2", "00-000", DateTime.Now);
            Assert.AreEqual(0, restaurantManager.GetCompletedOrders().Count, "Wrong completed orders number");
            Assert.AreEqual(1, restaurantManager.GetActiveOrders().Count, "Wrong active orders number");

            restaurantManager.CompleteOrder(0);

            Assert.AreEqual(1, restaurantManager.GetCompletedOrders().Count, "Wrong completed orders number");
            Assert.AreEqual(0, restaurantManager.GetActiveOrders().Count, "Wrong active orders number");
        }

        [TestMethod]
        public void TestCompleteDelivery()
        {
            DateTime orderTime = DateTime.Now.Date;
            restaurantManager.CreateDish("Chips", "testDishDescription", null, CategoryDTG.snack, 1.0);
            restaurantManager.CreateClient("John Smith", "111222333", "Street", "1", "90-200");
            restaurantManager.CreateClient("Matthew Johnson", "111222333", "Street", "1", "90-200");
            List<string> dishesNames = new List<string>();
            dishesNames.Add("Chips");

            restaurantManager.CreateOrder("John Smith", DateTime.Now, true, dishesNames, "Street", "2", "00-000", DateTime.Now);
            Assert.AreEqual(0, restaurantManager.GetCompletedDeliveries().Count, "Wrong completed deliveries number");
            Assert.AreEqual(1, restaurantManager.GetActiveDeliveries().Count, "Wrong active deliveries number");

            restaurantManager.CompleteDelivery(0);

            Assert.AreEqual(1, restaurantManager.GetCompletedDeliveries().Count, "Wrong completed deliveries number");
            Assert.AreEqual(0, restaurantManager.GetActiveDeliveries().Count, "Wrong active deliveries number");
        }
    }
}

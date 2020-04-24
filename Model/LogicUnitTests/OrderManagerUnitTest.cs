using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using Model;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace LogicUnitTests
{
    [TestClass]
    public class OrderManagerUnitTest
    {
        [TestMethod]
        public void CreatingOrderTest()
        {
            List<Task> tasksInProgress = new List<Task>();
            
            OrderManager orderManager = new OrderManager();
            tasksInProgress.Add(Task.Run(() => orderManager.CreateOrder(null, DateTime.Now, false, null)));
            tasksInProgress.Add(Task.Run(() => orderManager.CreateOrder(null, DateTime.Now, false, null)));

            Task.WaitAll(tasksInProgress.ToArray());
            Assert.AreEqual(2, orderManager.activeOrders.Count, "Wrong order number");
            Assert.AreNotEqual(orderManager.activeOrders[0].Id, orderManager.activeOrders[1].Id, "Orders ID are not unical");

        }

        [TestMethod]
        public void CompletingOrderTest()
        {
            List<Task> tasksInProgress = new List<Task>();

            OrderManager orderManager = new OrderManager();
            tasksInProgress.Add(Task.Run(() => orderManager.CreateOrder(null, DateTime.Now, false, null)));
            tasksInProgress.Add(Task.Run(() => orderManager.CreateOrder(null, DateTime.Now, false, null)));
            tasksInProgress.Add(Task.Run(() => orderManager.CreateOrder(null, DateTime.Now, false, null)));
            tasksInProgress.Add(Task.Run(() => orderManager.CompleteOrder(1)));

            Task.WaitAll(tasksInProgress.ToArray());
            Assert.AreEqual(2, orderManager.activeOrders.Count, "Wrong order number");
            Assert.AreEqual(1, orderManager.completedOrders.Count, "Wrong order number");
          

        }

        [TestMethod]
        public void GetOrderByIdTest()
        {
            List<Task> tasksInProgress = new List<Task>();

            OrderManager orderManager = new OrderManager();
            tasksInProgress.Add(Task.Run(() => orderManager.CreateOrder(null, DateTime.Now, false, null)));
            tasksInProgress.Add(Task.Run(() => orderManager.CreateOrder(null, DateTime.Now, true, null)));
            tasksInProgress.Add(Task.Run(() => orderManager.CompleteOrder(1)));

            Task.WaitAll(tasksInProgress.ToArray());
            Assert.AreEqual(false, orderManager.GetCompletedOrderById(1).Delivery, "Wrong order number");
          
           


        }
    }
}

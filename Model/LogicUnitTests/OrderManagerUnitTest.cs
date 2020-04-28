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
            tasksInProgress.Add(Task.Run(() => orderManager.CreateOrder(0,null, DateTime.Now,null, false, null, DateTime.Now.AddHours(1))));
            tasksInProgress.Add(Task.Run(() => orderManager.CreateOrder(1,null, DateTime.Now,null, false, null, DateTime.Now.AddHours(1))));

            Task.WaitAll(tasksInProgress.ToArray());
            Assert.AreEqual(2, orderManager.ActiveOrders.Count, "Wrong order number");
            Assert.AreNotEqual(orderManager.ActiveOrders[0].Id, orderManager.ActiveOrders[1].Id, "Orders ID are not unical");

        }

        [TestMethod]
        public void CompletingOrderTest()
        {
            List<Task> tasksInProgress = new List<Task>();

            OrderManager orderManager = new OrderManager();
            tasksInProgress.Add(Task.Run(() => orderManager.CreateOrder(0,null, DateTime.Now,null, false, null, DateTime.Now.AddHours(1))));
            tasksInProgress.Add(Task.Run(() => orderManager.CreateOrder(1,null, DateTime.Now,null, false, null, DateTime.Now.AddHours(1))));
            tasksInProgress.Add(Task.Run(() => orderManager.CreateOrder(2,null, DateTime.Now,null, false, null, DateTime.Now.AddHours(1))));
            
            Task.WaitAll(tasksInProgress.ToArray());

            tasksInProgress.Add(Task.Run(() => orderManager.CompleteOrder(1)));

            Task.WaitAll(tasksInProgress.ToArray());


            Assert.AreEqual(2, orderManager.ActiveOrders.Count, "Wrong order number");
            Assert.AreEqual(1, orderManager.CompletedOrders.Count, "Wrong order number");
          

        }

        [TestMethod]
        public void GetOrderByIdTest()
        {
            List<Task> tasksInProgress = new List<Task>();

            OrderManager orderManager = new OrderManager();
            tasksInProgress.Add(Task.Run(() => orderManager.CreateOrder(0,null, DateTime.Now,null, false, null,DateTime.Now.AddHours(1))));
            tasksInProgress.Add(Task.Run(() => orderManager.CreateOrder(1,null, DateTime.Now,null, true, null, DateTime.Now.AddHours(1))));
            Task.WaitAll(tasksInProgress.ToArray());

            tasksInProgress.Add(Task.Run(() => orderManager.CompleteOrder(1)));
            Task.WaitAll(tasksInProgress.ToArray());

            Assert.AreEqual(true, orderManager.CompletedOrders[0].Delivery, "Wrong delivery status");
          
           


        }
    }
}

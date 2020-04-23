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
            Assert.AreEqual(2, orderManager.Orders.Count, "Wrong order number");
            Assert.AreNotEqual(orderManager.Orders[0].Id, orderManager.Orders[1].Id, "Orders ID are not unical");

        }
    }
}

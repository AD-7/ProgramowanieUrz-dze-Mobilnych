using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using Dane;
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
                       
            OrderManager orderManager = new OrderManager();
            orderManager.CreateOrder(0,null, DateTime.Now, new List<DishDTG>(), false, null, DateTime.Now.AddHours(1));
            orderManager.CreateOrder(1,null, DateTime.Now, new List<DishDTG>(), false, null, DateTime.Now.AddHours(1));

            Assert.AreEqual(2, orderManager.ActiveOrders.Count, "Wrong order number");
            Assert.AreNotEqual(orderManager.ActiveOrders[0].Id, orderManager.ActiveOrders[1].Id, "Orders ID are not unical");

        }

        [TestMethod]
        public void CompletingOrderTest()
        {

            OrderManager orderManager = new OrderManager();
            orderManager.CreateOrder(0,null, DateTime.Now, new List<DishDTG>(), false, null, DateTime.Now.AddHours(1));
            orderManager.CreateOrder(1,null, DateTime.Now, new List<DishDTG>(), false, null, DateTime.Now.AddHours(1));
            orderManager.CreateOrder(2,null, DateTime.Now, new List<DishDTG>(), false, null, DateTime.Now.AddHours(1));
            
            orderManager.CompleteOrder(1);

            Assert.AreEqual(2, orderManager.ActiveOrders.Count, "Wrong order number");
            Assert.AreEqual(1, orderManager.CompletedOrders.Count, "Wrong order number");
          

        }

        [TestMethod]
        public void GetOrderByIdTest()
        {
           
            OrderManager orderManager = new OrderManager();
            orderManager.CreateOrder(0,null, DateTime.Now, new List<DishDTG>(), false, null,DateTime.Now.AddHours(1));
            orderManager.CreateOrder(1,null, DateTime.Now, new List<DishDTG>(), true, null, DateTime.Now.AddHours(1));

            orderManager.CompleteOrder(1);

            Assert.AreEqual(true, orderManager.CompletedOrders[0].Delivery, "Wrong delivery status");
          

        }
    }
}

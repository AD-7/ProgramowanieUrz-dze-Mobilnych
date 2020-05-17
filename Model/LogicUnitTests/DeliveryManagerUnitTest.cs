using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

using System.Threading.Tasks;
using System.Collections.Generic;

namespace LogicUnitTests
{
    [TestClass]
    public class DeliveryManagerUnitTest
    {
        [TestMethod]
        public void CreatingOrderTest()
        {
                       
            DeliveryManager deliveryManager = new DeliveryManager();
            deliveryManager.CreateOrder(0,null, DateTime.Now, new List<DishDTG>(), true, null, DateTime.Now.AddHours(1));
            deliveryManager.CreateOrder(1,null, DateTime.Now, new List<DishDTG>(), true, null, DateTime.Now.AddHours(1));

            Assert.AreEqual(2, deliveryManager.DeliveryOrders.Count, "Wrong order number");
            Assert.AreNotEqual(deliveryManager.DeliveryOrders[0].Id, deliveryManager.DeliveryOrders[1].Id, "Orders ID are not unical");

        }

        [TestMethod]
        public void CompletingOrderTest()
        {

            DeliveryManager deliveryManager = new DeliveryManager();
            deliveryManager.CreateOrder(0,null, DateTime.Now, new List<DishDTG>(), true, null, DateTime.Now.AddHours(1));
            deliveryManager.CreateOrder(1,null, DateTime.Now, new List<DishDTG>(), true, null, DateTime.Now.AddHours(1));
            deliveryManager.CreateOrder(2,null, DateTime.Now, new List<DishDTG>(), true, null, DateTime.Now.AddHours(1));

            deliveryManager.CompleteOrder(1);

            Assert.AreEqual(2, deliveryManager.DeliveryOrders.Count, "Wrong order number");
            Assert.AreEqual(1, deliveryManager.DeliveryCompleted.Count, "Wrong order number");
          

        }

        [TestMethod]
        public void GetOrderByIdTest()
        {

            DeliveryManager deliveryManager = new DeliveryManager();
            deliveryManager.CreateOrder(0,null, DateTime.Now, new List<DishDTG>(), false, null,DateTime.Now.AddHours(1));
            deliveryManager.CreateOrder(1,null, DateTime.Now, new List<DishDTG>(), true, null, DateTime.Now.AddHours(1));

            deliveryManager.CompleteOrder(1);

            Assert.AreEqual(true, deliveryManager.DeliveryCompleted[0].Delivery, "Wrong delivery status");
          

        }
    }
}

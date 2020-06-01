using System;
using System.Collections.Generic;
using ServerLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dane;

namespace LogicUnitTests
{
    [TestClass]
    public class RestaurantManagerUnitTest
    {
        [TestMethod]
        public void GenerateIncomeReportTest()
        {
            RestaurantManager restaurantManager = new RestaurantManager();
            restaurantManager.CreateClient("Jan Kowalski", "", "", "", "");
            restaurantManager.CreateDish("testDish", "", new List<IngredientDTG>(), CategoryDTG.alcohol, 15);
            restaurantManager.CreateDish("testDish2", "", new List<IngredientDTG>(), CategoryDTG.alcohol, 10.3);

            List<string> dishesNames = new List<string>();
            dishesNames.Add("testDish");
            dishesNames.Add("testDish2");
            dishesNames.Add("testDish");
            //ClientDTG client = new ClientDTG(1, "Jan Kowalski", "", null);

            restaurantManager.CreateOrder("Jan Kowalski", DateTime.Now, false, dishesNames, "", "", "", DateTime.Now.AddHours(1));
            Assert.AreEqual(1, restaurantManager.GetActiveOrders().Count, "Wrong number of active orders");

            restaurantManager.CompleteOrder(0);
            Assert.AreEqual(1, restaurantManager.GetCompletedOrders().Count, "Wrong number of completed orders");

            IncomeReport report = restaurantManager.GenerateIncomeReport(DateTime.Now.AddHours(-1), DateTime.Now.AddHours(1));
            Assert.AreEqual(40.3, report.Income, "Wrong income value");
        }
    }
}

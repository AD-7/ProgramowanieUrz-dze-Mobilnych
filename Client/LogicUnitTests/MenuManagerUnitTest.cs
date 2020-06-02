using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dane;
using ServerLogic;

namespace LogicUnitTests
{
    [TestClass]
    public class MenuManagerUnitTest
    {
        [TestMethod]
        public void AddDishToMenuTest()
        {
            MenuManager menuManager = new MenuManager();
            List<Dish> menu = menuManager.GetMenu();
            Assert.AreEqual(0, menu.Count, "Wrong dishes number");

            List<Ingredient> ingredients = new List<Ingredient>();
            menuManager.AddDishToMenu("testDish", "Description", ingredients, CategoryDTG.alcohol, 15.67);
            menuManager.AddDishToMenu("testDish2", "Description", ingredients, CategoryDTG.dinner, 20.75);
            menu = menuManager.GetMenu();

            Assert.AreEqual(2, menu.Count, "Wrong dishes number");
            Assert.AreEqual("testDish", menu[0].Name, "Wrong dish name");
            Assert.AreEqual(Category.dinner, menu[1].Category, "Wrong dish category");

        }

        [TestMethod]
        public void GetDishByNameTest()
        {
            MenuManager menuManager = new MenuManager();
            List<Dish> menu = menuManager.GetMenu();

            List<Ingredient> ingredients = new List<Ingredient>();
            menuManager.AddDishToMenu("testDish", "Description", ingredients, CategoryDTG.alcohol, 15.67);
            menuManager.AddDishToMenu("testDish2", "Description", ingredients, CategoryDTG.dinner, 20.75);
            menu = menuManager.GetMenu();

            Assert.AreEqual(1, menuManager.GetDishByName("testDish2").Id, "Wrong dish id");
            Assert.AreEqual(0, menuManager.GetDishByName("testDish").Id, "Wrong dish id");
        }
    }
}

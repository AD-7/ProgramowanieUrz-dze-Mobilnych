using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class MenuManager
    {       
        private List<Dish> Dishes { get;  set; } 
        private int currentMenuIndex;

        public MenuManager()
        {
            Dishes = new List<Dish>();
            currentMenuIndex = 0;
        }


        public void AddDishToMenu(string name, string description, List<Ingredient> ingredients, Category category, double price)
        {
            Dish dish = new Dish(currentMenuIndex, name, description, ingredients, category, price);
            Dishes.Add(dish);
            currentMenuIndex++;           
        }

        public List<Dish> GetMenu()
        {
            return Dishes;
        }

        public Dish GetDishById(int Id)
        {
            return Dishes.Find(x => x.Id == Id);
        }

        public Dish GetDishByName(string Name)
        {
            return Dishes.Find(x => x.Name == Name);

        }




    }
}

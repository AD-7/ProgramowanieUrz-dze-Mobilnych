using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class MenuManager
    {
        private readonly object menuCriticalSection = new object();
        private List<Dish> dishes { get;  set; } 
        private int currentMenuIndex;

        public MenuManager()
        {
            dishes = new List<Dish>();
            currentMenuIndex = 0;
        }


        public void AddDishToMenu(string name, string description, List<Ingredient> ingredients, Category category, double price)
        {
            lock (menuCriticalSection)
            {
                Dish dish = new Dish(currentMenuIndex, name, description, ingredients, category, price);
                dishes.Add(dish);
                currentMenuIndex++;
            }
        }

        public List<Dish> GetMenu()
        {
            return dishes;
        }

        public Dish GetDishById(int Id)
        {
            return dishes.Find(x => x.Id == Id);
        }

        public Dish GetDishByName(string Name)
        {
            return dishes.Find(x => x.Name == Name);

        }




    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Dane
{
    public class Menu
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public List<Dish> Dishes { get; private set; }

        public Menu(int id, string name, List<Dish> dishes)
        {
            Id = id;
            Name = name;
            Dishes = dishes;
        }
    }
}

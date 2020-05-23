using Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
 


    public class DishModel
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public CategoryDTG Category { get; private set; }
        public double Price { get; private set; }

        public DishModel(int id, string name, string description, CategoryDTG category, double price)
        {
            Id = id;
            Name = name;
            Description = description;
            Category = category;
            Price = price;
        }

        public DishModel(DishDTG dtg)
        {
            Id = dtg.Id;
            Name = dtg.Name;
            Description = dtg.Description;
            Category = dtg.Category;
            Price = dtg.Price;
        }
    }
}

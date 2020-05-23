using Dane;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public enum CategoryDTG
    {
        breakfast = 0,
        appetizer = 1,
        snack = 2,
        soup = 3,
        dinner = 4,
        drink = 5,
        alcohol = 6
    };

    public class DishDTG
    {
        public int Id { get;  set; }
        public string Name { get;  set; }
        public string Description { get;  set; }
        public List<IngredientDTG> Ingredients { get;  set; }
        public CategoryDTG Category { get;  set; }
        public double Price { get;  set; }

   
    }
}

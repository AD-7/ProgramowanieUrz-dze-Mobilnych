using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public enum Category
    {
        breakfast = 0,
        appetizer = 1,
        snack = 2,
        soup = 3,
        dinner = 4,
        drink = 5,
        alcohol = 6
    };



    public class Dish
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public List<Ingredient> Ingredients { get; private set; }
        public Category Category { get; private set; }
        public double Price { get; private set; }

        public Dish(int id, string name, string description, List<Ingredient> ingredients, Category category, double price)
        {
            Id = id;
            Name = name;
            Description = description;
            Ingredients = ingredients;
            Category = category;
            Price = price;
        }
    }
}

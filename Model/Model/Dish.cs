using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
     enum Category
    {
        breakfast = 0,
        appetizer = 1,
        snack = 2,
        soup = 3,
        dinner = 4,
        drink = 5,
        alcohol = 6
    };



    class Dish
    {
        int id;
        string name;
        string description;
        List<Ingredient> ingredients;
        Category category;
        double price;
    }
}

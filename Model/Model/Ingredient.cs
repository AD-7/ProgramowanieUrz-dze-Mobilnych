using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Ingredient
    {
        public Product Product { get; private set; }
        public int Quantity { get; private set; }

        public Ingredient(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}

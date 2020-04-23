using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Ingredient
    {
        public Product ProductName { get; private set; }
        public int Quantity { get; private set; }

        public Ingredient(Product productName, int quantity)
        {
            ProductName = productName;
            Quantity = quantity;
        }
    }
}

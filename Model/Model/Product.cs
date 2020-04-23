using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Product(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}

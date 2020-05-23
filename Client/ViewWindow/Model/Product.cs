using Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ProductModel
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public ProductModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public ProductModel(ProductDTG dtg)
        {
            Id = dtg.Id;
            Name = dtg.Name;
        }
    }
}

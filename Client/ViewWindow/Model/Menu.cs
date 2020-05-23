using Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class MenuModel
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public List<DishModel> Dishes { get; private set; }

        public MenuModel(int id, string name, List<DishModel> dishes)
        {
            Id = id;
            Name = name;
            Dishes = dishes;
        }

        public MenuModel(MenuDTG dtg)
        {
            Id = dtg.Id;
            Name = dtg.Name;
            Dishes = new List<DishModel>();
            foreach(DishDTG tmp in dtg.Dishes)
            {
                Dishes.Add(new DishModel(tmp));
            }
        }
    }
}

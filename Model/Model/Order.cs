using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    class Order
    {
        int id;
        string customerName;
        int phoneNumber;
        DateTime orderDate;
        List<Dish> dishes;
        bool delivery;
        Adress adress;
    }
}

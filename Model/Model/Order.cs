using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    class Order
    {
        int id;
        Client client;
        DateTime orderDate;
        List<Dish> dishes;
        bool delivery;
        Adress deliveryAdress;
        double totalPrice;
    }
}

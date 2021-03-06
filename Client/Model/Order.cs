﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dane
{
    public class Order
    {
        public int Id { get; private set; }
        public Client Client { get; private set; }
        public DateTime OrderDate { get; private set; }
        public DateTime CompleteOrderDate { get;  set; }
        public List<Dish> Dishes { get; private set; }
        public bool Delivery { get; private set; }
        public Address DeliveryAdress { get; private set; }
        public DateTime DeliveryEndTime { get; private set; }
        public double TotalPrice { get; private set; }

        public Order(int id, Client client, DateTime orderDate, List<Dish> dishes, bool delivery, Address deliveryAdress , DateTime deliveryEndTime)
        {
            Id = id;
            Client = client;
            OrderDate = orderDate;
            Dishes = dishes;
            Delivery = delivery;
            DeliveryAdress = deliveryAdress;
            TotalPrice = 0.0;
            foreach (Dish dish in dishes)
            {
                TotalPrice += dish.Price;
            }
            
            DeliveryEndTime = deliveryEndTime;
        }
    }
}

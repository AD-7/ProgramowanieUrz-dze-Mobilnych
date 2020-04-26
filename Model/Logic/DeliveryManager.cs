using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class DeliveryManager
    {       
        public List<Order> DeliveryOrders { get; private set; }
        public List<Order> DeliveryCompleted { get; private set; }
        public List<Order> LateOrders { get; private set; }

        public DeliveryManager()
        {
            DeliveryOrders = new List<Order>();
            DeliveryCompleted = new List<Order>();
            LateOrders = new List<Order>();
        }

        public void CreateOrder(int currentOrderIndex, Client client, DateTime orderDate, List<Dish> dishes, bool delivery, Address deliveryAddress, DateTime deliveryEndTime)
        {           
            Order order = new Order(currentOrderIndex, client, orderDate, dishes, delivery, deliveryAddress, deliveryEndTime);
            DeliveryOrders.Add(order);
        }

        public void CompleteOrder(int Id)
        {
            Order tmp = DeliveryOrders.Find(x => x.Id == Id);
            DeliveryOrders.RemoveAll(x => x.Id == Id);
            DeliveryCompleted.Add(tmp);
        }

        //TO DO: przenoszenie zamówień które przekroczyły czas dostawy do zamówień spóźnionychs

    }
}

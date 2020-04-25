using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class DeliveryManager
    {
        private readonly object deliveryCriticalSection = new object();
        public List<Order> deliveryOrders { get; private set; }
        public List<Order> deliveryCompleted { get; private set; }
        public List<Order> lateOrders { get; private set; }

        public DeliveryManager()
        {
            deliveryOrders = new List<Order>();
            deliveryCompleted = new List<Order>();
            lateOrders = new List<Order>();
        }

        public void CreateOrder(int currentOrderIndex, Client client, DateTime orderDate, bool delivery, Address deliveryAddress, DateTime deliveryEndTime)
        {
            lock (deliveryCriticalSection)
            {
                Order order = new Order(currentOrderIndex, client, orderDate, delivery, deliveryAddress, deliveryEndTime);
                deliveryOrders.Add(order);

            }
        }

        public void CompleteOrder(int Id)
        {
            Order tmp = deliveryOrders.Find(x => x.Id == Id);
            deliveryOrders.RemoveAll(x => x.Id == Id);
            deliveryCompleted.Add(tmp);
        }

        //TO DO: przenoszenie zamówień które przekroczyły czas dostawy do zamówień spóźnionychs

    }
}

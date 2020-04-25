using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Model;

namespace Logic
{
    public class OrderManager
    {
        private readonly object orderCriticalSection = new object();
        public List<Order> activeOrders { get; private set; }
        public List<Order> completedOrders { get; private set; }
        

        public OrderManager()
        {
            activeOrders = new List<Order>();
            completedOrders = new List<Order>();
         
        }

        public void CreateOrder(int currentOrderIndex,Client client, DateTime orderDate, bool delivery, Address deliveryAddress, DateTime deliveryEndTime)
        {
            lock (orderCriticalSection)
            {
                Order order = new Order(currentOrderIndex, client, orderDate, delivery, deliveryAddress, deliveryEndTime);
                activeOrders.Add(order);
                
            }
        }

        public void CompleteOrder(int Id)
        {
            Order tmp = activeOrders.Find(x => x.Id == Id);
            completedOrders.Add(new Order(tmp.Id,tmp.Client,tmp.OrderDate,tmp.Delivery,tmp.DeliveryAdress,tmp.DeliveryEndTime));
            activeOrders.RemoveAll(x => x.Id == Id);
          
        }

        public Order GetActiveOrderById(int Id)
        {
            return activeOrders.Find(o => o.Id == Id);
        }

        public Order GetCompletedOrderById(int Id)
        {
            return completedOrders.Find(o => o.Id == Id);
        }

    }
}

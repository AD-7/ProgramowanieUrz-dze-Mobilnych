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
        private int currentOrderIndex;

        public OrderManager()
        {
            activeOrders = new List<Order>();
            completedOrders = new List<Order>();
            currentOrderIndex = 0;
        }

        public void CreateOrder(Client client, DateTime orderDate, bool delivery, Address deliveryAddress)
        {
            lock (orderCriticalSection)
            {
                Order order = new Order(currentOrderIndex, client, orderDate, delivery, deliveryAddress);
                activeOrders.Add(order);
                currentOrderIndex++;
            }
        }

        public void CompleteOrder(int Id)
        {
            Order tmp = activeOrders.Find(x => x.Id == Id);
            activeOrders.RemoveAll(x => x.Id == Id);
            completedOrders.Add(tmp);
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

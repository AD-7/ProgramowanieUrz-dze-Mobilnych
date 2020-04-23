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
        public List<Order> Orders { get; private set; }
        private int currentOrderIndex;

        public OrderManager()
        {
            Orders = new List<Order>();
            currentOrderIndex = 0;
        }

        public void CreateOrder(Client client, DateTime orderDate, bool delivery, Address deliveryAddress)
        {
            lock (orderCriticalSection)
            {
                Order order = new Order(currentOrderIndex, client, orderDate, delivery, deliveryAddress);
                Orders.Add(order);
                currentOrderIndex++;
            }

        }


    }
}

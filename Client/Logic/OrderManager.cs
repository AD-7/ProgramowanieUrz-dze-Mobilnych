using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Dane;

namespace Logic
{
    public class OrderManager
    {        
        public List<Order> ActiveOrders { get; private set; }
        public List<Order> CompletedOrders { get; private set; }
        

        public OrderManager()
        {
            ActiveOrders = new List<Order>();
            CompletedOrders = new List<Order>();
         
        }

        public void CreateOrder(int currentOrderIndex,Client client, DateTime orderDate, List<DishDTG> dishes, bool delivery, Address deliveryAddress, DateTime deliveryEndTime)
        {
            List<Dish> dataDishes = new List<Dish>();
            foreach(DishDTG dtg in dishes)
            {
                int cat = Convert.ToInt32(dtg.Category);
                dataDishes.Add(new Dish(dtg.Id, dtg.Name, dtg.Description, null, (Category)cat, dtg.Price));
            }
            Order order = new Order(currentOrderIndex, client, orderDate, dataDishes, delivery, deliveryAddress, deliveryEndTime);
            ActiveOrders.Add(order);       
        }

        public void CompleteOrder(int Id)
        {
            Order tmp = ActiveOrders.Find(x => x.Id == Id);
            CompletedOrders.Add(new Order(tmp.Id,tmp.Client,tmp.OrderDate, tmp.Dishes, tmp.Delivery,tmp.DeliveryAdress,tmp.DeliveryEndTime));
            CompletedOrders[CompletedOrders.Count - 1].CompleteOrderDate = DateTime.Now;
            ActiveOrders.RemoveAll(x => x.Id == Id);
          
        }

        public Order GetActiveOrderById(int Id)
        {
            return ActiveOrders.Find(o => o.Id == Id);
        }

        public Order GetCompletedOrderById(int Id)
        {
            return CompletedOrders.Find(o => o.Id == Id);
        }

    }
}

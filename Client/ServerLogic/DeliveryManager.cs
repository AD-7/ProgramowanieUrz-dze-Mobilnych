using Dane;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerLogic
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

        public void CreateOrder(int currentOrderIndex, Client client, DateTime orderDate, List<DishDTG> dishes, bool delivery, Address deliveryAddress, DateTime deliveryEndTime)
        {
            List<Dish> dataDishes = new List<Dish>();
            foreach (DishDTG dtg in dishes)
            {
                int cat = Convert.ToInt32(dtg.Category);
                dataDishes.Add(new Dish(dtg.Id, dtg.Name, dtg.Description, null, (Category)cat, dtg.Price));
            }
            Order order = new Order(currentOrderIndex, client, orderDate, dataDishes, delivery, deliveryAddress, deliveryEndTime);
            DeliveryOrders.Add(order);
        }

        public void CompleteOrder(int Id)
        {
            Order tmp = DeliveryOrders.Find(x => x.Id == Id);
            DeliveryOrders.RemoveAll(x => x.Id == Id);
            tmp.CompleteOrderDate = DateTime.Now;
            DeliveryCompleted.Add(tmp);
        }
        public Order GetDeliveryById(int Id)
        {
            return DeliveryOrders.Find(x => x.Id == Id);
        }

    }
}

using Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class OrderModel
    {
        public int Id { get; private set; }
        public ClientModel Client { get; private set; }
        public DateTime OrderDate { get; private set; }
        public DateTime CompleteOrderDate { get;  set; }
        public List<DishModel> Dishes { get; private set; }
        public bool Delivery { get; private set; }
        public AddressModel DeliveryAdress { get; private set; }
        public DateTime DeliveryEndTime { get; private set; }
        public double TotalPrice { get; private set; }

        public OrderModel(int id, ClientModel client, DateTime orderDate, List<DishModel> dishes, bool delivery, AddressModel deliveryAdress , DateTime deliveryEndTime)
        {
            Id = id;
            Client = client;
            OrderDate = orderDate;
            Dishes = dishes;
            Delivery = delivery;
            DeliveryAdress = deliveryAdress;
            TotalPrice = 0.0;
            foreach (DishModel dish in dishes)
            {
                TotalPrice += dish.Price;
            }
            
            DeliveryEndTime = deliveryEndTime;
        }

        public OrderModel(OrderDTG dtg)
        {
            Id = dtg.Id;
            Client = new ClientModel(dtg.Client);
            OrderDate = dtg.OrderDate;
            Dishes = new List<DishModel>();
            foreach(DishDTG tmp in dtg.Dishes)
            {
                Dishes.Add(new DishModel(tmp));
            }
            Delivery = dtg.Delivery;
            DeliveryAdress = new AddressModel(dtg.DeliveryAdress);
            TotalPrice = dtg.TotalPrice;
            DeliveryEndTime = dtg.DeliveryEndTime;
        }
    }
}

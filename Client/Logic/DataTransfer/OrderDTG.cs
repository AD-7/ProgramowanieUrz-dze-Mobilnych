using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class OrderDTG
    {
        public int Id { get;  set; }
        public ClientDTG Client { get;  set; }
        public DateTime OrderDate { get;  set; }
        public List<DishDTG> Dishes { get;  set; }
        public DateTime CompleteOrderDate { get;  set; }
        public bool Delivery { get;  set; }
        public AddressDTG DeliveryAdress { get;  set; }
        public DateTime DeliveryEndTime { get;  set; }
        public double TotalPrice { get;  set; }

       
    }
}

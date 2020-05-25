using Dane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Logic
{
    public class Deserializer
    {
        public static List<DishDTG> Deserialize_Menu(string obj)
        {
            obj = obj.Replace("/n", "");
            using (var stringreader = new System.IO.StringReader(obj))
            {

                var serializer = new XmlSerializer(typeof(List<DishDTG>));
                
               return serializer.Deserialize(stringreader) as List<DishDTG>;
            }
        }

        public static List<OrderDTG> Deserialize_Orders(string obj)
        {
            obj = obj.Replace("/n", "");
            using (var stringreader = new System.IO.StringReader(obj))
            {

                var serializer = new XmlSerializer(typeof(List<OrderDTG>));

                return serializer.Deserialize(stringreader) as List<OrderDTG>;
            }
        }
        public static OrderDTG Deserialize_Order(string obj)
        {
            obj = obj.Replace("/n", "");
            using (var stringreader = new System.IO.StringReader(obj))
            {

                var serializer = new XmlSerializer(typeof(OrderDTG));

                return serializer.Deserialize(stringreader) as OrderDTG;
            }
        }
        public static List<ClientDTG> Deserialize_Clients(string obj)
        {
            obj = obj.Replace("/n", "");
            using (var stringreader = new System.IO.StringReader(obj))
            {

                var serializer = new XmlSerializer(typeof(List<ClientDTG>));

                return serializer.Deserialize(stringreader) as List<ClientDTG>;
            }
        }

    }
}

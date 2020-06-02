
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Communication
{
    public static class Serializer
    {
       

        public static string SerializeCommunicationType(CommunicationType cmd)
        {
            using (var stringwriter = new System.IO.StringWriter())
            {

                var serializer = new XmlSerializer(typeof(CommunicationType));
                serializer.Serialize(stringwriter, cmd);
                string result = stringwriter.ToString();
                return result;
            }
        }


       public static string Serialize(Object obj)
        {
            using (var stringwriter = new System.IO.StringWriter())
            {
                
                var serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(stringwriter, obj );
                string result = stringwriter.ToString();
                return result;
            }
        }




    }
}

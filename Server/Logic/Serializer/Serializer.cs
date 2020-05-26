using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Logic.Serializer
{
    public class Serializer
    {
       
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

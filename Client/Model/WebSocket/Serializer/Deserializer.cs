
using Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Communication
{
    public class Deserializer
    {


        public static CommunicationType Deserialize(string msg)
        {
            using (var stringreader = new System.IO.StringReader(msg))
            {

                var serializer = new XmlSerializer(typeof(CommunicationType));

                return serializer.Deserialize(stringreader) as CommunicationType;
            }
        }



       

    }
}

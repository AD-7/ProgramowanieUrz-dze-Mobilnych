using System;
using System.Collections.Generic;
using System.Text;

namespace Dane
{
    public class Client
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public Address Adress { get; private set; }

        public Client(int id, string name, string phoneNumber, Address adress)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Adress = adress;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Client
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public Adress Adress { get; private set; }

        public Client(int id, string name, string phoneNumber, Adress adress)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Adress = adress;
        }
    }
}

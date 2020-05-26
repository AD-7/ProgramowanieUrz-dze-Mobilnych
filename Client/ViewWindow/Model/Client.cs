using Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ClientModel
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public AddressModel Adress { get; private set; }

        public ClientModel(int id, string name, string phoneNumber, AddressModel adress)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Adress = adress;
        }

        public ClientModel(ClientDTG dtg)
        {
            Id = dtg.Id;
            Name = dtg.Name;
            PhoneNumber = dtg.PhoneNumber;
            Adress = new AddressModel(dtg.Adress);
        }
    }
}

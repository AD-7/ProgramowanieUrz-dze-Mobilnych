using Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model

{
    public class AddressModel
    {
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string PostalCode { get; private set; }

        public AddressModel(string street, string number, string postalCode)
        {
            Street = street;
            Number = number;
            PostalCode = postalCode;
        }

        public AddressModel(AddressDTG dtg)
        {
            Street = dtg.Street;
            Number = dtg.Number;
            PostalCode = dtg.PostalCode;
        }
    }
}

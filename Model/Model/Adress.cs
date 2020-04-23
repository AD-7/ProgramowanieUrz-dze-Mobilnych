using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Adress
    {
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string PostalCode { get; private set; }

        public Adress(string street, string number, string postalCode)
        {
            Street = street;
            Number = number;
            PostalCode = postalCode;
        }
    }
}

using Dane;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class ClientManager
    {       
        public List<Client> Clients { get; private set; }
        private int currentClientIndex;

        public ClientManager()
        {
            Clients = new List<Client>();
            currentClientIndex = 0;
        }


        public void CreateClient(string name, string phoneNumber, Address adress)
        {
           
            if (!Clients.Exists(x => x.Name == name))
            {
                Client client = new Client(currentClientIndex, name, phoneNumber, adress);
                Clients.Add(client);
                currentClientIndex++;
            }
           
        }

        public Client GetClientByName(string name)
        {
            return Clients.Find(x => x.Name == name);
        }


    }
}

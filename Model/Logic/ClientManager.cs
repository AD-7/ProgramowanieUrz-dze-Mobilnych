using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class ClientManager
    {
        private readonly object clientCriticalSection = new object();
        public List<Client> clients { get; private set; }
        private int currentClientIndex;



        public ClientManager()
        {
            clients = new List<Client>();
            currentClientIndex = 0;
        }


        public void CreateClient(string name, string phoneNumber, Address adress)
        {
            lock (clientCriticalSection)
            {
                Client client = new Client(currentClientIndex,name, phoneNumber, adress);
                clients.Add(client);
                currentClientIndex++;
            }
        }



    }
}

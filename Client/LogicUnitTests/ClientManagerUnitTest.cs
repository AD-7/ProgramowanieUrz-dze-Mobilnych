using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ServerLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicUnitTests
{
    [TestClass]
    public class ClientManagerUnitTest
    {
        [TestMethod]
        public void CreateClientTest()
        {

            ClientManager clientManager = new ClientManager();
            clientManager.CreateClient("test1", "", null);
            clientManager.CreateClient("test2", "", null);

            Assert.AreEqual(2, clientManager.Clients.Count, "Wrong order number");
            Assert.AreEqual(0, clientManager.Clients[0].Id, "Wrong order ID");
            Assert.AreEqual(1, clientManager.Clients[1].Id, "Wrong order ID");

        }

        [TestMethod]
        public void GetClientByNameTest()
        {

            ClientManager clientManager = new ClientManager();

            clientManager.CreateClient("test1", "", null);
            clientManager.CreateClient("test2", "", null);

            Assert.AreEqual(1, clientManager.GetClientByName("test2").Id, "Wrong order ID");
            Assert.AreEqual(0, clientManager.GetClientByName("test1").Id, "Wrong order ID");

        }


    }
}

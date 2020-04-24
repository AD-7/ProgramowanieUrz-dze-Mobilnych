using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicUnitTests
{
    [TestClass]
    public class ClientManagerUnitTest
    {
        [TestMethod]
        public void CreateClientTest()
        {

            List<Task> tasksInProgress = new List<Task>();
            ClientManager clientManager = new ClientManager();

            tasksInProgress.Add(Task.Run(() => clientManager.CreateClient("test1","",null)));
            tasksInProgress.Add(Task.Run(() => clientManager.CreateClient("test2", "", null)));

            Task.WaitAll(tasksInProgress.ToArray());

            Assert.AreEqual(2, clientManager.clients.Count, "Wrong order number");
            Assert.AreNotEqual(clientManager.clients[0].Id, clientManager.clients[1].Id, "Orders ID are not unical");

        }

        [TestMethod]
        public void GetClientByNameTest()
        {

            List<Task> tasksInProgress = new List<Task>();
            ClientManager clientManager = new ClientManager();

            tasksInProgress.Add(Task.Run(() => clientManager.CreateClient("test1", "", null)));
            tasksInProgress.Add(Task.Run(() => clientManager.CreateClient("test2", "", null)));

            Task.WaitAll(tasksInProgress.ToArray());

            Assert.AreEqual(1, clientManager.GetClientByName("test2").Id, "Wrong order number");
          

        }






    }
}

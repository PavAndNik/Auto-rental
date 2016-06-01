using AutoRental.Data.EF;
using AutoRental.Data.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Services_Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.SqlServer;

namespace ServicesTest
{
    [TestClass]

    public class OrderItemServiceAsyncTests
    {
        private readonly ServicesClientAsync service;

        public OrderItemServiceAsyncTests()
        {
  
            this.service = new ServicesClientAsync(new ClientRepository(new DataContext("defaultconnection")));

            service.AddAsync(new Client
            {
                Name = "Client1",
                Login = "Client1",
                Password = "1234",
                Email = "Client@gmail.com",
                DateOfBirth = new DateTime(1999, 12, 1),
                Surname = "SClient1",
                DriverLicenseNumber="121",
                PassportNumber="121",
                PhoneNumber="1111111"
            }).Wait();
            service.AddAsync(new Client
            {
                Name = "Client2",
                Login = "Client2",
                Password = "1234",
                Email = "Clien2@gmail.com",
                DateOfBirth = new DateTime(1999, 12, 1),
                Surname = "SClient2",
                DriverLicenseNumber = "1231",
                PassportNumber = "1211",
                PhoneNumber = "11111111"
            }).Wait();
        }

        [TestMethod]
        public void AddTest()
        {
            var name = Guid.NewGuid().ToString();
             

            var newClient =new Client
            {
                Name = name,
                Login = name,
                Password = "1234"+name,
                Email = name+"@gmail.com",
                DateOfBirth = new DateTime(1999, 12, 1),
                Surname = "S"+name,
                DriverLicenseNumber = "1231",
                PassportNumber = "1211",
                PhoneNumber = "11111111"
            };

            var addedClientTask = service.AddAsync(newClient);

            var addedClient = addedClientTask.Result;

            Assert.IsNotNull(addedClient);
            Assert.IsTrue(addedClient.Id > 0);
            Assert.AreEqual(addedClient.Name, name);
        }
        [TestMethod]
        public void GetByIdTest()
        {
            var client = service.GetAsync(1).Result;

            Assert.IsNotNull(client);
            Assert.AreEqual(client.Id, 1);
        }

        [TestMethod]
        public void GetAllTest()
        {
            var clientList = service.GetAsync().Result;

            Assert.IsNotNull(clientList);
            Assert.IsTrue(clientList.Count > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            var client = service.GetAsync().Result.Last();
            service.DeleteAsync(client.Id).Wait();

            var deletedClient = service.GetAsync(client.Id).Result;

            Assert.IsNull(deletedClient);
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void DeleteNotFoundTest()
        {
            service.DeleteAsync(int.MaxValue)
                .Wait();
        }
    }
}

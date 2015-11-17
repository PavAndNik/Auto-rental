using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System.Linq;
using System.Collections.Generic;
using Services.Services_Async;

namespace ServicesTest
{
    [TestClass]
    public class ServicesClientTestAsync
    {

        private readonly ServicesClientAsync service;

        public ServicesClientTestAsync()
        {
            this.service = new ServicesClientAsync();

            service.AddAsync(new Client
            {
                Name = "Client1",
                Login = "Client1",
                Password = "1234",
                Email = "Client@gmail.com",
                DateOfBirth = new DateTime(1999, 12, 1),
                Surname = "SClient1",
            }).Wait();
            service.AddAsync(new Client
            {
                Name = "Client2",
                Login = "Client2",
                Password = "1234",
                Email = "Clien2@gmail.com",
                DateOfBirth = new DateTime(1999, 12, 1),
                Surname = "SClient2",
            }).Wait();
        }

        [TestMethod]
        public void AddTestAsync()
        {
            string login = Guid.NewGuid().ToString();
            string password = Guid.NewGuid().ToString();
            string email = Guid.NewGuid().ToString();
            string name = Guid.NewGuid().ToString();
            string surname = Guid.NewGuid().ToString();

            Client newClient = new Client { Email = email, Login = login, Password = password, Surname = surname, Name = name };
            var addedClientTask = service.AddAsync(newClient);

            var addedClient = addedClientTask.Result;

            Assert.IsNotNull(addedClient);
            Assert.IsTrue(addedClient.Id > 0);
            Assert.AreEqual(addedClient.Email, email);
            Assert.AreEqual(addedClient.Login, login);
            Assert.AreEqual(addedClient.Password, password);
            Assert.AreEqual(addedClient.Name, name);
            Assert.AreEqual(addedClient.Surname, surname);
        }

        [TestMethod] 
         public void GetByIdTestAsync()
         { 
            Client client = service.GetAsync(1).Result;
            Assert.IsNotNull(client);
            Assert.AreEqual(client.Id, 1);
        }

         
         [TestMethod] 
        public void GetByIdEditTestAsync()
         { 
            Client client = service.GetAsync(1).Result;
            string login = client.Login;
            string password = client.Password;
            string email = client.Email;
            string phoneNumber = client.PhoneNumber;
            string name = client.Name;
            string surname = client.Surname;
            client.Login = Guid.NewGuid().ToString();
            client.Password = Guid.NewGuid().ToString();
            client.Email = Guid.NewGuid().ToString();
            client.PhoneNumber = Guid.NewGuid().ToString();
            Client newClient = service.GetAsync(1).Result;
            Assert.AreEqual(newClient.Login, login);
            Assert.AreEqual(newClient.Password, password);
            Assert.AreEqual(newClient.Email, email);
            Assert.AreEqual(newClient.PhoneNumber, phoneNumber);
            Assert.AreEqual(newClient.Name, name);
            Assert.AreEqual(newClient.Surname, surname);
        }

        [TestMethod] 
         public void GetByIdNotFoundTestAsync()
         { 
            Client client = service.GetAsync(int.MaxValue).Result;
            Assert.IsNull(client);
        }

        [TestMethod] 
         public void GetAllTestAsync()
         { 
            List<Client> clients = service.GetAsync().Result;
            Assert.IsNotNull(clients);
            Assert.IsTrue(clients.Count > 0);
        }

        [TestMethod] 
         public void UpdateTestAsync()
         { 
            Client client = service.GetAsync().Result.First();
            client.Email += "upd";
            client.Login += "upd";
            client.Password += "upd";
            client.PhoneNumber += "upd";
            client.Name += "upd";
            client.Surname += "upd";
            service.UpdateAsync(client).Wait();
            Client updatedClient = service.GetAsync(client.Id).Result;
            Assert.IsNotNull(updatedClient);
            Assert.AreEqual(updatedClient.Email, client.Email);
            Assert.AreEqual(updatedClient.Login, client.Login);
            Assert.AreEqual(updatedClient.Password, client.Password);
            Assert.AreEqual(updatedClient.PhoneNumber, client.PhoneNumber);
            Assert.AreEqual(updatedClient.Name, client.Name);
            Assert.AreEqual(updatedClient.Surname, client.Surname);
        }

        [TestMethod] 
         [ExpectedException(typeof(AggregateException))] 
         public void UpdateNotFoundTestAsync()
         {
            service.UpdateAsync(new Client { Id = int.MaxValue }).Wait();
         }

        [TestMethod] 
         public void DeleteTestAsync()
         { 
            Client client = service.GetAsync().Result.Last();
            service.DeleteAsync(client.Id).Wait();
            Client deletedClient = service.GetAsync(client.Id).Result;
            Assert.IsNull(deletedClient);
        }

        [TestMethod] 
         [ExpectedException(typeof(AggregateException))] 
         public void DeleteNotFoundTestAsync()
         { 
             service.DeleteAsync(int.MaxValue) 
                 .Wait();
        }

}
}

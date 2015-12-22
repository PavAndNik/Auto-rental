using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System.Linq;
using System.Collections.Generic;
using Services.AuditServices;

namespace ServicesTest
{
    [TestClass]
    public class ServicesClientTest
    {
        private readonly ServicesClient service;

        public ServicesClientTest()
        {
            this.service = new ServicesClient(new AuditManager());
            service.Add(new Client
            {
                Name = "Client13",
                Login = "Client1",
                Password = "1234",
                Email = "Client@gmail.com",
                DateOfBirth = new DateTime(1999,12,1),
                Surname = "SClient1",
            });
            service.Add(new Client
            {
                Name = "Client2",
                Login = "Client2",
                Password = "1234",
                Email = "Clien2@gmail.com",
                DateOfBirth = new DateTime(1999, 12, 1),
                Surname = "SClient2",
            });
        }
        [TestMethod]
        public void AddTest()
        {
            string login = Guid.NewGuid().ToString();
            string password = Guid.NewGuid().ToString();
            string email = Guid.NewGuid().ToString();
            string name = Guid.NewGuid().ToString();
            string surname = Guid.NewGuid().ToString();

            Client newClient = new Client { Email = email, Login = login, Password = password, Surname = surname, Name = name };
            Client addedClient = service.Add(newClient);
            Assert.IsNotNull(addedClient);
            Assert.IsTrue(addedClient.Id > 0);
            Assert.AreEqual(addedClient.Email, email);
            Assert.AreEqual(addedClient.Login, login);
            Assert.AreEqual(addedClient.Password, password);
            Assert.AreEqual(addedClient.Name, name);
            Assert.AreEqual(addedClient.Surname, surname);
        }

        [TestMethod] 
         public void GetByIdTest()
         { 
             Client client = service.Get(1); 
             Assert.IsNotNull(client); 
             Assert.AreEqual(client.Id, 1); 
         }
        [TestMethod] 
         public void GetByIdEditTest()
         { 
             Client client = service.Get(1); 
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
             Client newClient = service.Get(1); 
             Assert.AreEqual(newClient.Login, login); 
             Assert.AreEqual(newClient.Password, password); 
             Assert.AreEqual(newClient.Email, email); 
             Assert.AreEqual(newClient.PhoneNumber, phoneNumber);
            Assert.AreEqual(newClient.Name, name);
            Assert.AreEqual(newClient.Surname, surname);
        }
        [TestMethod] 
         public void GetByIdNotFoundTest()
         { 
            Client client = service.Get(int.MaxValue);
             Assert.IsNull(client); 
         }
        [TestMethod] 
         public void GetAllTest()
         { 
             List<Client> clients = service.Get(); 
             Assert.IsNotNull(clients); 
             Assert.IsTrue(clients.Count > 0); 
         }
        [TestMethod] 
         public void UpdateTest()
         { 
             Client client = service.Get().First(); 
             client.Email += "upd"; 
             client.Login += "upd"; 
             client.Password += "upd"; 
             client.PhoneNumber += "upd";
            client.Name += "upd";
            client.Surname += "upd";
            service.Update(client); 
             Client updatedClient = service.Get(client.Id); 
             Assert.IsNotNull(updatedClient); 
             Assert.AreEqual(updatedClient.Email, client.Email); 
             Assert.AreEqual(updatedClient.Login, client.Login); 
             Assert.AreEqual(updatedClient.Password, client.Password); 
             Assert.AreEqual(updatedClient.PhoneNumber, client.PhoneNumber);
            Assert.AreEqual(updatedClient.Name, client.Name);
            Assert.AreEqual(updatedClient.Surname, client.Surname);
        }

        [TestMethod] 
         [ExpectedException(typeof(NullReferenceException))] 
         public void UpdateNotFoundTest()
         { 
             service.Update(new Client {Id = int.MaxValue }); 
         }

        [TestMethod] 
         public void DeleteTest()
         { 
             Client client = service.Get().Last(); 
             service.Delete(client.Id); 
             Client deletedClient = service.Get(client.Id); 
             Assert.IsNull(deletedClient); 
         } 
 
 
         [TestMethod] 
         [ExpectedException(typeof(NullReferenceException))] 
         public void DeleteNotFoundTest()
         { 
             service.Delete(int.MaxValue); 
         } 




}
}

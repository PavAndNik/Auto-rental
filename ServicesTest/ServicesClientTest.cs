using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System.Linq;

namespace ServicesTest
{
    [TestClass]
    public class ServicesClientTest
    {
        private ServicesClient service;

        public ServicesClientTest()
        {
            service = new ServicesClient();
            service.Add(new Client
            {
                Name = "Client2",
                Login = "Client",
                Password = "1234",
                Email = "Client@gmail.com",
                DateOfBirth = "11.11.11",
                Surname = "SClient",
            });
        }

        [TestMethod]
        public void GetAllTest()
        {
            var items = service.Get();
            Assert.IsTrue(items.Count > 0);
        }

        [TestMethod]
        public void GetItemTest()
        {
            const int clientId = 1;
            var client = service.Get(clientId);
            Assert.IsNotNull(client);
            Assert.AreEqual(client.Id, clientId);
        }

        [TestMethod]
        public void GetItemNotFoundTest()
        {
            var client = service.Get(int.MaxValue);
            Assert.IsNull(client);
        }

        [TestMethod]
        public void AddItemTest()
        {
            var items = service.Get().ToArray();
            var guid = Guid.NewGuid().ToString();
            var guPassw = Guid.NewGuid().ToString();
            var guSurname = Guid.NewGuid().ToString();
            var guPassportNumber = Guid.NewGuid().ToString();
            var client = new Client
            {
                Name = guid,
                Password = guPassw,
                Surname = guSurname,
                PassportNumber = guPassportNumber

            };

            service.Add(client);

            var newItems = service.Get();
            Assert.IsTrue(items.Length + 1 == newItems.Count);

            var addedClient = newItems.FirstOrDefault(item => item.Name.Equals(guid));

            Assert.IsNotNull(addedClient);
            Assert.IsTrue(addedClient.Id > 0);
            Assert.IsTrue(newItems.Select(item => item.Id).Distinct().Count() == newItems.Count);
        }

        [TestMethod]
        public void UpdateItemTest()
        {
            var item = service.Get().FirstOrDefault() ?? service.Add(new Client
            {
                Name = "Test",
                Login = "Client",
                Password = "1234",
                Email = "Client@gmail.com",
                DateOfBirth = "11.11.11",
                Surname = "SClient",
                PassportNumber = "1234567890"
            });

            var guid = Guid.NewGuid().ToString();

            item.Name = guid;

            service.Update(item);

            var newItem = service.Get(item.Id);

            Assert.AreEqual(newItem.Name, guid);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void UpdateItemNotFoundTest()
        {
            var notFoundClient = new Client
            {
                Id = int.MaxValue,
                Name = "Some name"
            };

            service.Update(notFoundClient);
        }

        [TestMethod]
        public void DeleteItemTest()
        {
            var item = service.Get().FirstOrDefault() ?? service.Add(new Client
            {
                Name = "Test",
                Login = "Client",
                Password = "1234",
                Email = "Client@gmail.com",
                DateOfBirth = "11.11.11",
                Surname = "SClient",
                PassportNumber = "1234567890"
            });
            service.Delete(item.Id);
            var deletedItem = service.Get(item.Id);

            Assert.IsNull(deletedItem);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DeleteItemNotFoundTest()
        {
            service.Delete(int.MaxValue);
        }
    }
}

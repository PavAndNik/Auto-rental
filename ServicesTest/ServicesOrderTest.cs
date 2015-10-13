using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System.Linq;
using System.Collections.Generic;

namespace ServicesTest
{
    [TestClass]
    class ServicesOrderTest
    {
        private ServicesOrder service;

        public ServicesOrderTest()
        {
            service = new ServicesOrder();
            service.Add(new Order
            {
                Name = "Order2",
                ListOfProducts = new List<Product>(),
                FullPrice = 1234,
                Buyer = new Client(),
                DateOfOrder = new DateTime(1222,12,24),
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
            const int OrderId = 1;
            var Order = service.Get(OrderId);
            Assert.IsNotNull(Order);
            Assert.AreEqual(Order.Id, OrderId);
        }

        [TestMethod]
        public void GetItemNotFoundTest()
        {
            var Order = service.Get(int.MaxValue);
            Assert.IsNull(Order);
        }

        [TestMethod]
        public void AddItemTest()
        {
            var items = service.Get().ToArray();
            var guid = Guid.NewGuid().ToString();
            var guPassw = Guid.NewGuid().ToString();
            var guSurname = Guid.NewGuid().ToString();
            var guPassportNumber = Guid.NewGuid().ToString();
            var Order = new Order
            {
                Name = guid,
                //Password = guPassw,
                //Surname = guSurname,
                //PassportNumber = guPassportNumber

            };

            service.Add(Order);

            var newItems = service.Get();
            Assert.IsTrue(items.Length + 1 == newItems.Count);

            var addedOrder = newItems.FirstOrDefault(item => item.Name.Equals(guid));

            Assert.IsNotNull(addedOrder);
            Assert.IsTrue(addedOrder.Id > 0);
            Assert.IsTrue(newItems.Select(item => item.Id).Distinct().Count() == newItems.Count);
        }

        [TestMethod]
        public void UpdateItemTest()
        {
            var item = service.Get().FirstOrDefault() ?? service.Add(new Order
            {
                Name = "Order2",
                ListOfProducts = new List<Product>(),
                FullPrice = 1234,
                Buyer = new Client(),
                DateOfOrder = new DateTime(1222, 12, 24),
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
            var notFoundOrder = new Order
            {
                Id = int.MaxValue,
                Name = "Some name"
            };

            service.Update(notFoundOrder);
        }

        [TestMethod]
        public void DeleteItemTest()
        {
            var item = service.Get().FirstOrDefault() ?? service.Add(new Order
            {
                Name = "Order2",
                ListOfProducts = new List<Product>(),
                FullPrice = 1234,
                Buyer = new Client(),
                DateOfOrder = new DateTime(1222, 12, 24),
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

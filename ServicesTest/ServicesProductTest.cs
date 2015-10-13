using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System.Linq;
using System.Collections.Generic;
using AutoRental.Model;


namespace ServicesTest
{
    [TestClass]
    public class ServicesProductTest
    {

        private ServicesProduct service;

        public ServicesProductTest()
        {
            service = new ServicesProduct();
            service.Add(new Product
            {
                Name = "Product",
                Price = 300,
                Producer = "1234",
                Type = "car",
                Cost = 300,
                DateOfCreation = new DateTime(12, 12, 12),
                Discount = 50,

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
            const int productId = 1;
            var product = service.Get(productId);
            Assert.IsNotNull(product);
            Assert.AreEqual(product.Id, productId);
        }

        [TestMethod]
        public void GetItemNotFoundTest()
        {
            var product = service.Get(int.MaxValue);
            Assert.IsNull(product);
        }

        [TestMethod]
        public void AddItemTest()
        {
            var items = service.Get().ToArray();
            var guid = Guid.NewGuid().ToString();
            var guProducer = Guid.NewGuid().ToString();
            var guType = Guid.NewGuid().ToString();
            var product = new Product
            {
                Name = guid,
                Producer = guProducer,
                Type = guType,

            };

            service.Add(product);

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
            var item = service.Get().FirstOrDefault() ?? service.Add(new Product
            {
                Name = "Product",
                Price = 300,
                Producer = "1234",
                Type = "car",
                Cost = 300,
                DateOfCreation = new DateTime(12, 12, 12),
                Discount = 50,
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
            var notFoundProduct = new Product
            {
                Id = int.MaxValue,
                Name = "Some name"
            };

            service.Update(notFoundProduct);
        }

        [TestMethod]
        public void DeleteItemTest()
        {
            var item = service.Get().FirstOrDefault() ?? service.Add(new Product
            {
                Name = "Product",
                Price = 300,
                Producer = "1234",
                Type = "car",
                Cost = 300,
                DateOfCreation = new DateTime(12, 12, 12),
                Discount = 50,
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

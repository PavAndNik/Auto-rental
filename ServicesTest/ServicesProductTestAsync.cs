using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System.Linq;
using System.Collections.Generic;
using Services.Services_Async;
using AutoRental.Model;

namespace ServicesTest
{
    [TestClass]
    public class ServicesProductTestAsync
    {

        private readonly ServicesProductAsync service;

        public ServicesProductTestAsync()
        {
            this.service = new ServicesProductAsync();

            service.AddAsync(new Product
            {
                Name = "Product1",
                Characteristics = new List<Characteristic>(),
                Cost = 1000,
                DateOfCreation = new DateTime(2001, 01, 01),
                Discount = 10,
                Price = 1000000,
                Producer = "Producer1",
                Type = "Type1"
            }).Wait();
            service.AddAsync(new Product
            {
                Name = "Product2",
                Characteristics = new List<Characteristic>(),
                Cost = 2000,
                DateOfCreation = new DateTime(2002, 02, 02),
                Discount = 20,
                Price = 2000000,
                Producer = "Producer2",
                Type = "Type2"
            }).Wait();
        }

        [TestMethod]
        public void AddTestAsync()
        {
            string name = Guid.NewGuid().ToString();
            int price = 1000001;
            DateTime dateOfCreation = new DateTime(2015, 10, 10);
            List<Characteristic> characteristics = new List<Characteristic>();
            int cost = 1000;
            int discount = 10;
            string producer = Guid.NewGuid().ToString();
            string type = Guid.NewGuid().ToString();

            Product newProduct = new Product { Name = name, Characteristics = characteristics, Cost = cost, DateOfCreation = dateOfCreation, Discount = discount, Price = price, Producer = producer, Type = type };
            var addedProductTask= service.AddAsync(newProduct);
            Product addedProduct = addedProductTask.Result;
            Assert.IsNotNull(addedProduct);
            Assert.IsTrue(addedProduct.Id > 0);
            Assert.AreEqual(addedProduct.Price, price);
            Assert.AreEqual(addedProduct.Producer, producer);
            Assert.AreEqual(addedProduct.Type, type);
            Assert.AreEqual(addedProduct.Name, name);
            Assert.AreEqual(addedProduct.Cost, cost);
            Assert.AreEqual(addedProduct.DateOfCreation, dateOfCreation);
            Assert.AreEqual(addedProduct.Characteristics, characteristics);
            Assert.AreEqual(addedProduct.Discount, discount);
        }

        [TestMethod] 
         public void GetByIdTestAsync()
         { 
            Product product = service.GetAsync(1).Result;
            Assert.IsNotNull(product);
            Assert.AreEqual(product.Id, 1);
        }

         
         [TestMethod] 
        public void GetByIdEditTestAsync()
         { 
            Product product = service.GetAsync(1).Result;
            string name = product.Name;
            Decimal price = product.Price;
            DateTime dateOfCreation = product.DateOfCreation;
            List<Characteristic> characteristics = product.Characteristics;
            int cost = product.Cost;
            int discount = product.Discount;
            string producer = product.Producer;
            string type = product.Type;

            product.Price = Decimal.MaxValue;
            product.Name = Guid.NewGuid().ToString();
            product.DateOfCreation = new DateTime(2015, 10, 10);
            product.Characteristics = new List<Characteristic>();
            product.Cost = 1000;
            product.Discount = 10;
            product.Producer = Guid.NewGuid().ToString();
            product.Type = Guid.NewGuid().ToString();

            Product newProduct = service.GetAsync(1).Result;
            Assert.AreEqual(newProduct.Cost, cost);
            Assert.AreEqual(newProduct.DateOfCreation, dateOfCreation);
            Assert.AreEqual(newProduct.Price, price);
            Assert.AreEqual(newProduct.Characteristics, characteristics);
            Assert.AreEqual(newProduct.Name, name);
            Assert.AreEqual(newProduct.Discount, discount);
            Assert.AreEqual(newProduct.Producer, producer);
            Assert.AreEqual(newProduct.Type, type);
        }

        [TestMethod] 
         public void GetByIdNotFoundTestAsync()
         { 
            Product product = service.GetAsync(int.MaxValue).Result;
            Assert.IsNull(product);
        }

        [TestMethod] 
         public void GetAllTestAsync()
         { 
            List<Product> products = service.GetAsync().Result;
            Assert.IsNotNull(products);
            Assert.IsTrue(products.Count > 0);
        }

        [TestMethod] 
         public void UpdateTestAsync()
         { 
            Product product = service.GetAsync().Result.First();
            product.Name += "upd";
            product.Price += 1;
            product.DateOfCreation = new DateTime(2015, 01, 02);
            product.Type += "upd";
            product.Producer += "upd";
            service.UpdateAsync(product).Wait();
            Product updatedProduct = service.GetAsync(product.Id).Result;
            Assert.IsNotNull(updatedProduct);
            Assert.AreEqual(updatedProduct.Price, product.Price);
            Assert.AreEqual(updatedProduct.DateOfCreation, product.DateOfCreation);
            Assert.AreEqual(updatedProduct.Name, product.Name);
            Assert.AreEqual(updatedProduct.Type, product.Type);
            Assert.AreEqual(updatedProduct.Producer, product.Producer);
        }

        [TestMethod] 
         [ExpectedException(typeof(AggregateException))] 
         public void UpdateNotFoundTestAsync()
         {
            service.UpdateAsync(new Product { Id = int.MaxValue }).Wait();
        }

        [TestMethod] 
         public void DeleteTestAsync()
         { 
            Product product = service.GetAsync().Result.Last();
            service.DeleteAsync(product.Id).Wait();
            Product deletedProduct = service.GetAsync(product.Id).Result;
            Assert.IsNull(deletedProduct);
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

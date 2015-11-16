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
        private readonly ServicesProduct service;

        public ServicesProductTest()
        {
            this.service = new ServicesProduct();
            service.Add(new Product
            {
                Name = "Product1",
                Characteristics = new List<Characteristic>(),
                Cost=1000,
                DateOfCreation=new DateTime(2001,01,01),
                Discount=10,
                Price=1000000,
                Producer = "Producer1",
                Type="Type1"
            });
            service.Add(new Product
            {
                Name = "Product2",
                Characteristics = new List<Characteristic>(),
                Cost = 2000,
                DateOfCreation = new DateTime(2002, 02, 02),
                Discount = 20,
                Price = 2000000,
                Producer = "Producer2",
                Type = "Type2"
            });
        }
        [TestMethod]
        public void AddTest()
        {

            string name = Guid.NewGuid().ToString();
            int price = 1000001;
            DateTime dateOfCreation = new DateTime(2015, 10, 10);
            List<Characteristic> characteristics = new List<Characteristic>();
            int cost = 1000;
            int discount = 10;
            string producer = Guid.NewGuid().ToString();
            string type = Guid.NewGuid().ToString();

            Product newProduct = new Product { Name = name,Characteristics=characteristics,Cost=cost,DateOfCreation=dateOfCreation,Discount=discount,Price=price,Producer=producer,Type=type };
            Product addedProduct = service.Add(newProduct);
            Assert.IsNotNull(addedProduct);
            Assert.IsTrue(addedProduct.Id > 0);
            Assert.AreEqual(addedProduct.Price, price);
            Assert.AreEqual(addedProduct.Producer,producer);
            Assert.AreEqual(addedProduct.Type, type);
            Assert.AreEqual(addedProduct.Name, name);
            Assert.AreEqual(addedProduct.Cost, cost);
            Assert.AreEqual(addedProduct.DateOfCreation, dateOfCreation);
            Assert.AreEqual(addedProduct.Characteristics, characteristics);
            Assert.AreEqual(addedProduct.Discount, discount);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            Product product = service.Get(1);
            Assert.IsNotNull(product);
            Assert.AreEqual(product.Id, 1);
        }
        [TestMethod]
        public void GetByIdEditTest()
        {
            Product product = service.Get(1);
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

            Product newProduct = service.Get(1);
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
        public void GetByIdNotFoundTest()
        {
            Product product = service.Get(int.MaxValue);
            Assert.IsNull(product);
        }
        [TestMethod]
        public void GetAllTest()
        {
            List<Product> products = service.Get();
            Assert.IsNotNull(products);
            Assert.IsTrue(products.Count > 0);
        }
        [TestMethod]
        public void UpdateTest()
        {
            Product product = service.Get().First();
            product.Name += "upd";
            product.Price += 1;
            product.DateOfCreation = new DateTime(2015, 01, 02);
            product.Type += "upd";
            product.Producer += "upd";
            service.Update(product);
            Product updatedProduct = service.Get(product.Id);
            Assert.IsNotNull(updatedProduct);
            Assert.AreEqual(updatedProduct.Price, product.Price);
            Assert.AreEqual(updatedProduct.DateOfCreation, product.DateOfCreation);
            Assert.AreEqual(updatedProduct.Name, product.Name);
            Assert.AreEqual(updatedProduct.Type, product.Type);
            Assert.AreEqual(updatedProduct.Producer, product.Producer);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void UpdateNotFoundTest()
        {
            service.Update(new Product { Id = int.MaxValue });
        }

        [TestMethod]
        public void DeleteTest()
        {
            Product product = service.Get().Last();
            service.Delete(product.Id);
            Product deletedProduct = service.Get(product.Id);
            Assert.IsNull(deletedProduct);
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DeleteNotFoundTest()
        {
            service.Delete(int.MaxValue);
        }

    }
}

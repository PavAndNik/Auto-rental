using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System.Linq;
using System.Collections.Generic;
using Services.AuditServices;

namespace ServicesTest
{
    [TestClass]
    public class ServicesOrderTest
    {
        private readonly ServicesOrder service;

        public ServicesOrderTest()
        {
            this.service = new ServicesOrder(new AuditManager());
            service.Add(new Order
            {
                Name = "Order1",
                FullPrice = 10000,
                Buyer = new Client(),
                DateOfOrder = new DateTime(2015, 11, 11),
                ListOfProducts = new List<Product>()
            });
            service.Add(new Order
            {
                Name = "Order2",
                FullPrice = 20000,
                Buyer = new Client(),
                DateOfOrder = new DateTime(2015, 10, 10),
                ListOfProducts = new List<Product>()
            });
        }
        [TestMethod]
        public void AddTest()
        {
          
            string name = Guid.NewGuid().ToString();
            int price = 1000001;
            Client buyer = new Client();
             DateTime  dateOfOrder = new DateTime(2015, 10, 10);
            List<Product> listOfProducts = new List<Product>();

            Order newOrder = new Order { Name = name, FullPrice = price, Buyer = buyer, DateOfOrder = dateOfOrder, ListOfProducts =listOfProducts };
            Order addedOrder = service.Add(newOrder);
            Assert.IsNotNull(addedOrder);
            Assert.IsTrue(addedOrder.Id > 0);
            Assert.AreEqual(addedOrder.FullPrice, price);
            Assert.AreEqual(addedOrder.Buyer, buyer);
            Assert.AreEqual(addedOrder.DateOfOrder, dateOfOrder);
            Assert.AreEqual(addedOrder.Name, name);
            Assert.AreEqual(addedOrder.ListOfProducts, listOfProducts);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            Order order = service.Get(1);
            Assert.IsNotNull(order);
            Assert.AreEqual(order.Id, 1);
        }
        [TestMethod]
        public void GetByIdEditTest()
        {
            Order order = service.Get(1);
            string name = order.Name;
            Decimal price = order.FullPrice;
            DateTime date = order.DateOfOrder;
            List<Product> listOfProduct = order.ListOfProducts;
            Client buyer = order.Buyer;

            order.Buyer = new Client();
            order.DateOfOrder = new DateTime(2015,01,01);
            order.FullPrice = Decimal.MaxValue;
            order.Name = Guid.NewGuid().ToString();
            order.ListOfProducts = new List<Product>();
           
             Order newOrder = service.Get(1);
            Assert.AreEqual(newOrder.Buyer, buyer);
            Assert.AreEqual(newOrder.DateOfOrder, date);
            Assert.AreEqual(newOrder.FullPrice, price);
            Assert.AreEqual(newOrder.ListOfProducts, listOfProduct);
            Assert.AreEqual(newOrder.Name, name);
        }
        [TestMethod]
        public void GetByIdNotFoundTest()
        {
            Order order = service.Get(int.MaxValue);
            Assert.IsNull(order);
        }
        [TestMethod]
        public void GetAllTest()
        {
            List<Order> orders = service.Get();
            Assert.IsNotNull(orders);
            Assert.IsTrue(orders.Count > 0);
        }
        [TestMethod]
        public void UpdateTest()
        {
            Order order = service.Get().First();
            order.Name += "upd";
            order.FullPrice += 1;
            order.DateOfOrder =new  DateTime(2015,01,02);
            service.Update(order);
            Order updatedOrder = service.Get(order.Id);
            Assert.IsNotNull(updatedOrder);
            Assert.AreEqual(updatedOrder.FullPrice, order.FullPrice);
            Assert.AreEqual(updatedOrder.DateOfOrder, order.DateOfOrder);
            Assert.AreEqual(updatedOrder.Name, order.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void UpdateNotFoundTest()
        {
            service.Update(new Order { Id = int.MaxValue });
        }

        [TestMethod]
        public void DeleteTest()
        {
            Order order = service.Get().Last();
            service.Delete(order.Id);
            Order deletedProduct = service.Get(order.Id);
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

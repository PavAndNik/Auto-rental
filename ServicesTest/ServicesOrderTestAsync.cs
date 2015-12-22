using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System.Linq;
using System.Collections.Generic;
using Services.Services_Async;
using Services.AuditServices;

namespace ServicesTest
{
    [TestClass]
    public class ServicesOrderTestAsync
    {

        private readonly ServicesOrderAsync service;

        public ServicesOrderTestAsync()
        {
            this.service = new ServicesOrderAsync(new AuditManager());
           
            service.AddAsync(new Order
            {
                Name = "Order1",
                FullPrice = 10000,
                Buyer = new Client(),
                DateOfOrder = new DateTime(2015, 11, 11),
                ListOfProducts = new List<Product>()
            }).Wait();
            service.AddAsync(new Order
            {
                Name = "Order2",
                FullPrice = 20000,
                Buyer = new Client(),
                DateOfOrder = new DateTime(2015, 10, 10),
                ListOfProducts = new List<Product>()
            }).Wait();
        }

        [TestMethod]
        public void AddTestAsync()
        {
            string name = Guid.NewGuid().ToString();
            int price = 1000001;
            Client buyer = new Client();
            DateTime dateOfOrder = new DateTime(2015, 10, 10);
            List<Product> listOfProducts = new List<Product>();

            Order newOrder = new Order { Name = name, FullPrice = price, Buyer = buyer, DateOfOrder = dateOfOrder, ListOfProducts = listOfProducts };
            var addedOrderTask = service.AddAsync(newOrder);
            var addedOrder = addedOrderTask.Result;
            Assert.IsNotNull(addedOrder);
            Assert.IsTrue(addedOrder.Id > 0);
            Assert.AreEqual(addedOrder.FullPrice, price);
            Assert.AreEqual(addedOrder.Buyer, buyer);
            Assert.AreEqual(addedOrder.DateOfOrder, dateOfOrder);
            Assert.AreEqual(addedOrder.Name, name);
            Assert.AreEqual(addedOrder.ListOfProducts, listOfProducts);
        }

        [TestMethod] 
         public void GetByIdTestAsync()
         { 
            Order order = service.GetAsync(1).Result;
            Assert.IsNotNull(order);
            Assert.AreEqual(order.Id, 1);
        }

         
         [TestMethod] 
        public void GetByIdEditTestAsync()
         { 
            Order order = service.GetAsync(1).Result;
            string name = order.Name;
            Decimal price = order.FullPrice;
            DateTime date = order.DateOfOrder;
            List<Product> listOfProduct = order.ListOfProducts;
            Client buyer = order.Buyer;

            order.Buyer = new Client();
            order.DateOfOrder = new DateTime(2015, 01, 01);
            order.FullPrice = Decimal.MaxValue;
            order.Name = Guid.NewGuid().ToString();
            order.ListOfProducts = new List<Product>();

            Order newOrder = service.GetAsync(1).Result;
            Assert.AreEqual(newOrder.Buyer, buyer);
            Assert.AreEqual(newOrder.DateOfOrder, date);
            Assert.AreEqual(newOrder.FullPrice, price);
            Assert.AreEqual(newOrder.ListOfProducts, listOfProduct);
            Assert.AreEqual(newOrder.Name, name);
        }

        [TestMethod] 
         public void GetByIdNotFoundTestAsync()
         { 
            Order order = service.GetAsync(int.MaxValue).Result;
            Assert.IsNull(order);
        }

        [TestMethod] 
         public void GetAllTestAsync()
         { 
            List<Order> orders = service.GetAsync().Result;
            Assert.IsNotNull(orders);
            Assert.IsTrue(orders.Count > 0);
        }

        [TestMethod] 
         public void UpdateTestAsync()
         { 
            Order order = service.GetAsync().Result.First();
            order.Name += "upd";
            order.FullPrice += 1;
            order.DateOfOrder = new DateTime(2015, 01, 02);
            service.UpdateAsync(order).Wait();
            Order updatedOrder = service.GetAsync(order.Id).Result;
            Assert.IsNotNull(updatedOrder);
            Assert.AreEqual(updatedOrder.FullPrice, order.FullPrice);
            Assert.AreEqual(updatedOrder.DateOfOrder, order.DateOfOrder);
            Assert.AreEqual(updatedOrder.Name, order.Name);
        }

        [TestMethod] 
         [ExpectedException(typeof(AggregateException))] 
         public void UpdateNotFoundTestAsync()
         {
            service.UpdateAsync(new Order { Id = int.MaxValue }).Wait();
        }

        [TestMethod] 
         public void DeleteTestAsync()
         { 
            Order order = service.GetAsync().Result.Last();
            service.DeleteAsync(order.Id).Wait();
            Order deletedProduct = service.GetAsync(order.Id).Result;
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

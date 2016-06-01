using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System.Linq;
using System.Collections.Generic;
using AutoRental.Services;
using AutoRental.Data.Model;
using AutoRental.Data.EF;

namespace ServicesTest
{
    [TestClass]
    public class ServicesOrderTestAsync
    {

        private readonly ServicesOrderAsync service;

        public ServicesOrderTestAsync()
        {
            this.service = new ServicesOrderAsync(new OrderRepository(new DataContext("defaultconnection")));

            service.AddAsync(new Order
            {
                
                FullPrice = 10000,
                DateOfOrder = new DateTime(2015, 11, 11),
                BuyerId=1
            }).Wait();
            service.AddAsync(new Order
            {
                FullPrice = 20000,
                DateOfOrder = new DateTime(2015, 11, 11),
                BuyerId = 2
            }).Wait();
        }

        [TestMethod]
        public void AddTestAsync()
        {
           
            int price = 1000001;
            DateTime dateOfOrder = new DateTime(2015, 10, 10);
            int BId = 3;


            Order newOrder = new Order { FullPrice = price, BuyerId = BId, DateOfOrder = dateOfOrder};
            var addedOrderTask = service.AddAsync(newOrder);
            var addedOrder = addedOrderTask.Result;
            Assert.IsNotNull(addedOrder);
            Assert.IsTrue(addedOrder.Id > 0);
            Assert.AreEqual(addedOrder.FullPrice, price);
            Assert.AreEqual(addedOrder.DateOfOrder, dateOfOrder);
            Assert.AreEqual(addedOrder.BuyerId, BId);
        }

        [TestMethod] 
         public void GetByIdTestAsync()
         { 
            Order order = service.GetAsync(1).Result;
            Assert.IsNotNull(order);
            Assert.AreEqual(order.Id, 1);
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
            order.BuyerId = 3;
            order.FullPrice += 1;
            order.DateOfOrder = new DateTime(2015, 01, 02);
            service.UpdateAsync(order).Wait();
            Order updatedOrder = service.GetAsync(order.Id).Result;
            Assert.IsNotNull(updatedOrder);
            Assert.AreEqual(updatedOrder.FullPrice, order.FullPrice);
            Assert.AreEqual(updatedOrder.DateOfOrder, order.DateOfOrder);
            Assert.AreEqual(updatedOrder.BuyerId, order.BuyerId);
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

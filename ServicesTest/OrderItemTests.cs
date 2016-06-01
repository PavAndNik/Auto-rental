using AutoRental.Data.EF;
using AutoRental.Data.Model;
using AutoRental.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesTest
{
    [TestClass]
    public class OrderItemTests
    {
        private readonly ServicesOrderItemAsync service;
        private readonly ServicesProductAsync serviceProduct;
        private readonly ServicesOrderAsync serviceOrder;

        public OrderItemTests()
        {

            this.service = new ServicesOrderItemAsync(new OrderItemRepository(new DataContext("defaultconnection")));
            this.serviceOrder = new ServicesOrderAsync(new OrderRepository(new DataContext("defaultconnection")));
            this.serviceProduct= new ServicesProductAsync(new ProductRepository(new DataContext("defaultconnection")));
            Product p1 = serviceProduct.GetAsync(1).Result;
            Product p2 = serviceProduct.GetAsync(2).Result;
            Order o1 = serviceOrder.GetAsync(1).Result;
            Order o2 = serviceOrder.GetAsync(2).Result;
            p1.Name = "blabla";
            serviceProduct.UpdateAsync(p1).Wait();
            service.AddAsync(new OrderItem
            {
            Product= p1,
            Order= o1,
            OrderId=o1.Id,
            ProductId=p1.Id,
            Quantity=1
            
            }).Wait();
            service.AddAsync(new OrderItem
            {
                Product = p2,
                Order = o2,
                OrderId = o2.Id,
                ProductId = p2.Id,
                Quantity = 2

            }).Wait();
        }

        [TestMethod]
        public void AddTest()
        {
            Product p = serviceProduct.GetAsync(3).Result;
           
            Order o = serviceOrder.GetAsync(3).Result;
            Console.WriteLine(p.Name);
            var newOrderItem = new OrderItem
            {
               Order=o,
               Product=p,
               OrderId=o.Id,
               ProductId=p.Id,
               Quantity=1
            };

            var addedOrderItemTask = service.AddAsync(newOrderItem);

            var addedOrderItem = addedOrderItemTask.Result;

            Assert.IsNotNull(addedOrderItem);
            Assert.IsTrue(addedOrderItem.Id > 0);
            Assert.AreEqual(addedOrderItem.Order, o);
            Assert.AreEqual(addedOrderItem.Product, p);
            Assert.AreEqual(addedOrderItem.OrderId, o.Id);
            Assert.AreEqual(addedOrderItem.ProductId, p.Id);
        }
        [TestMethod]
        public void GetByIdTest()
        {
            var orderItem = service.GetAsync(1).Result;

            Assert.IsNotNull(orderItem);
            Assert.AreEqual(orderItem.Id, 1);
        }

        [TestMethod]
        public void GetAllTest()
        {
            var orderItemList = service.GetAsync().Result;

            Assert.IsNotNull(orderItemList);
            Assert.IsTrue(orderItemList.Count > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            var orderItem = service.GetAsync().Result.Last();
            service.DeleteAsync(orderItem.Id).Wait();

            var deletedOrderItem = service.GetAsync(orderItem.Id).Result;

            Assert.IsNull(deletedOrderItem);
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void DeleteNotFoundTest()
        {
            service.DeleteAsync(int.MaxValue)
                .Wait();
        }
    }
}

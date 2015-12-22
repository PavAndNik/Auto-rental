using AutoRental.Audit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class ServicesOrder
    {
        private static List<Order> listOfOrders = new List<Order>();
        private readonly IAuditManager auditManager;

        public ServicesOrder(IAuditManager auditManager)
        {
            this.auditManager = auditManager;
        }
        public Order Get(int id)
        {
            foreach (Order o in listOfOrders)
                if (o.Id == id) return (Order)o.Clone();
            this.auditManager.Access(typeof(Order), AccessType.Read);
            return null;
        }

        public List<Order> Get()
        {
            this.auditManager.Access(typeof(Order), AccessType.Read);
            return listOfOrders;
        }

        public Order Add(Order OrderForAdd)
        {
            OrderForAdd.Id = listOfOrders.Any() ? listOfOrders.Max(item => item.Id) + 1 : 1;
            listOfOrders.Add(OrderForAdd);
            this.auditManager.Access(typeof(Order), AccessType.Add);
            return (Order)OrderForAdd.Clone();
        }

        public Order Update(Order OrderForUpdate)
        {
            var Order = this.Get(OrderForUpdate.Id);
            if (Order == null)
            {
                throw new NullReferenceException();
            }

            Order.Name = OrderForUpdate.Name;
            Order.ListOfProducts = OrderForUpdate.ListOfProducts;
            Order.FullPrice = OrderForUpdate.FullPrice;
            Order.Buyer = OrderForUpdate.Buyer;
            Order.DateOfOrder = OrderForUpdate.DateOfOrder;

            this.auditManager.Access(typeof(Order), AccessType.Update);

            return (Order)Order.Clone();
        }

        public void Delete(int id)
        {
            Order order = listOfOrders.SingleOrDefault(item => item.Id == id);
            if (order == null) throw new NullReferenceException();
            listOfOrders.Remove(order);

            this.auditManager.Access(typeof(Order), AccessType.Delete);
        }
    }
}

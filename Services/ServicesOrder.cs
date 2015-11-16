using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class ServicesOrder
    {
        private static List<Order> listOfOrders = new List<Order>();

        public Order Get(int id)
        {
            foreach (Order o in listOfOrders)
                if (o.Id == id) return (Order)o.Clone();
            return null;
        }

        public List<Order> Get()
        {
            return listOfOrders;
        }

        public Order Add(Order OrderForAdd)
        {
            OrderForAdd.Id = listOfOrders.Any() ? listOfOrders.Max(item => item.Id) + 1 : 1;
            listOfOrders.Add(OrderForAdd);
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

            return (Order)Order.Clone();
        }

        public void Delete(int id)
        {
            Order order = listOfOrders.SingleOrDefault(item => item.Id == id);
            if (order == null) throw new NullReferenceException();
            listOfOrders.Remove(order);
        }
    }
}

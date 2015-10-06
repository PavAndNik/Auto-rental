using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRental.Services
{
    class ServicesOrder
    {
        private List<Order> ListOfOrder = new List<Order>();
        public void AddOrder(Order NewOrder)
        {
            NewOrder.Id = ListOfOrder.Last<Order>().Id + 1;
            ListOfOrder.Add(NewOrder);
        }
        public Order GetOrder(string ID)
        {
            foreach (Order p in ListOfOrder)
            {
                if (p.Id == ID)
                    return p;
            }
            return null;
        }
        public void DeleteOrder(string ID)
        {
            foreach (Order p in ListOfOrder)
            {
                if (p.Id == ID)
                    ListOfOrder.Remove(p);
            }
        }
        public void UpdateOrder(Order P)
        {
            int index = ListOfOrder.IndexOf(P);
            if (index != -1)
            {
                ListOfOrder[index] = P;
            }
            else AddOrder(P);
        }
    }
}

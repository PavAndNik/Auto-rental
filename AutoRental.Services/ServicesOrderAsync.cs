using AutoRental.Data.EF;
using AutoRental.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRental.Services
{
      public class ServicesOrderAsync : DomainServiceAsync<Order>
    {
        private readonly List<Order> entities = new List<Order>();

        public ServicesOrderAsync(OrderRepository repository) : base(repository)
        {

        }
    }
}

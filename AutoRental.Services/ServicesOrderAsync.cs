using AutoRental.Data;
using AutoRental.Data.EF;
using AutoRental.Data.Model;
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
              public ServicesOrderAsync(IOrderRepository repository) : base(repository)
        {

        }
    }
}

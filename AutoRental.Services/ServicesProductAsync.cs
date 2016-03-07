using AutoRental.Data.EF;
using AutoRental.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRental.Services
{
    public class ServicesProductAsync : DomainServiceAsync<Product>
    {
        private readonly List<Product> entities = new List<Product>();

        public ServicesProductAsync(ProductRepository repository) : base(repository)
        {

        }
    }
}

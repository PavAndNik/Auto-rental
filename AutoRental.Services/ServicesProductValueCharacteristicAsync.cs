using AutoRental.Data;
using AutoRental.Data.Model;
using AutoRental.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRental.Services
{
    
    public class ServicesProductValueCharacteristicAsync : DomainServiceAsync<ProductValueCharacteristic>
    {
        public ServicesProductValueCharacteristicAsync(IProductValueCharacteristicRepository repository) : base(repository)
        {

        }

        public async Task<List<ProductValueCharacteristic>> GetByProductId(int productid)
        {
            return await base.repository.GetAsync(pc => pc.ProductId == productid);
        }
    }
}

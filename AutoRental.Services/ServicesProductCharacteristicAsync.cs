using AutoRental.Data;
using AutoRental.Data.EF;
using AutoRental.Data.Model;
using AutoRental.Services.Common;
using System.Collections.Generic;

namespace AutoRental.Services
{
    public class ServicesProductCharacteristicAsync : DomainServiceAsync<Characteristic>
    {
       public ServicesProductCharacteristicAsync(IProductCharacteristicRepository repository) : base(repository)
        {

        }
    }
 
}

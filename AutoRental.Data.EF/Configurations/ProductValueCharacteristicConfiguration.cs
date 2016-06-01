using AutoRental.Data.EF.Configurations.Common;
using AutoRental.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRental.Data.EF
{

    public class ProductValueCharacteristicConfiguration : BaseModelConfiguration<ProductValueCharacteristic>
    {
        public ProductValueCharacteristicConfiguration()
        {
            Property(p => p.CharacteristicId).IsRequired();
            Property(p => p.ProductId).IsRequired();
            Property(p => p.Value).IsRequired();

            HasRequired(p => p.Characteristic).WithMany().HasForeignKey(p => p.CharacteristicId);
            HasRequired(p => p.Product).WithMany().HasForeignKey(p => p.ProductId);
        }
    }
}

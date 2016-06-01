using AutoRental.Data.EF.Configurations.Common;
using AutoRental.Data.Model;

namespace AutoRental.Data.EF.Configurations
{
    class ProductCharacteristicConfiguration : BaseModelConfiguration<Characteristic>
    {
        public ProductCharacteristicConfiguration()
        {
            Property(p => p.Value).IsRequired();
        }
    }
 
}

using AutoRental.Data.EF.Common;
using AutoRental.Data.Model;

namespace AutoRental.Data.EF
{
    public class ProductCharacteristicRepository : Repository<Characteristic>, IProductCharacteristicRepository
    {
        public ProductCharacteristicRepository(DataContext context) : base(context)
        {

        }
    }

}

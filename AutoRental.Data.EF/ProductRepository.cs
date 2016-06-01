using AutoRental.Data.EF.Common;
using AutoRental.Data.Model;

namespace AutoRental.Data.EF
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DataContext context) : base(context)
        {

        }
    }
}

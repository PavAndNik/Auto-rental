using AutoRental.Data.EF.Common;
using AutoRental.Data.Model;

namespace AutoRental.Data.EF
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(DataContext context) : base(context)
        {

        }
    }
}

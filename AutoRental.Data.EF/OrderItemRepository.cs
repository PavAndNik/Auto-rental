using AutoRental.Data.EF.Common;
using AutoRental.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRental.Data.EF
{
    public class OrderItemRepository : Repository<OrderItem>,IOrderItemRepository
    {
        public OrderItemRepository(DataContext context) : base(context)
        {

        }
        public List<OrderItem> GetByOrderId(int id)
        {
            return base.Set.Where(oi => oi.OrderId == id).ToList();//.Select(oi => oi.Product);
        }
    }
}

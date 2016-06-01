using AutoRental.Data.EF.Configurations.Common;
using AutoRental.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRental.Data.EF.Configurations
{
    public class OrderConfiguration : BaseModelConfiguration<Order>
    {
        public OrderConfiguration()
        {
            Property(p => p.DateOfOrder).IsRequired();
            Property(p => p.FullPrice).IsRequired();
            Property(p => p.BuyerId).IsRequired();

            //HasMany(m => m.ListOfProducts).WithMany().Map(m => m.MapLeftKey("OrderId").MapRightKey("ProductId"));

            //HasRequired(m => m.Buyer).WithMany(m=>m.Orders).Map(m => m.MapKey("ClientId"));

        }
    }
}

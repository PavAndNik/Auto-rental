using AutoRental.Data.EF.Configurations.Common;
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
            Property(p => p.Name).HasMaxLength(50).IsRequired();
            
            HasRequired(m => m.ListOfProducts).WithMany().HasForeignKey(m => m.Id);//Надо спросить про связи
            HasRequired(m => m.Buyer).WithOptional().Map(m => m.MapKey("ClientId"));
        }
    }
}

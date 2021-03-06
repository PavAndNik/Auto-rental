﻿using AutoRental.Data.EF.Configurations.Common;
using AutoRental.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRental.Data.EF.Configurations
{
   public class ProductConfiguration : BaseModelConfiguration<Product>
    {
        public ProductConfiguration()
        {
            Property(p => p.Name).HasMaxLength(50).IsRequired();
            Property(p => p.Price).IsRequired();
            Property(p => p.Producer).HasMaxLength(50).IsRequired();
            Property(p => p.Type).IsRequired();
            Property(p => p.Cost).IsRequired();
            Property(p => p.DateOfCreation).IsRequired();
            Property(p => p.Discount).IsRequired();

            //HasMany(m => m.Characteristics).WithRequired().Map(m => m.MapKey("ProductCharacteristicConfigurationId"));

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRental.Model
{
    public class ProductCharacteristic : BusinesObject
    {
        public Product Product { get; set; }
        public String Value { get; set; }

        public override object Clone()
        {
            return new ProductCharacteristic
            {
                Id = this.Id,
                Name = this.Name,
                Product=this.Product,
                Value=this.Value
            };
        }
    }
}

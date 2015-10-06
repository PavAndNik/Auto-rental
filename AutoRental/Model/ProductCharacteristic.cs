using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRental.Model
{
    class ProductCharacteristic
    {
        public Product Product { get; set; }
        public Characteristic Characteristic { get; set; }
        public String Value { get; set; }
    }
}

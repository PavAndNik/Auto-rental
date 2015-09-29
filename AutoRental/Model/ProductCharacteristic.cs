using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRental.Model
{
    class ProductCharacteristic
    {
        public Product ProductForCharacteristic { get; set; }
        public Characteristic CharacteristicForProduct { get; set; }
        public String Value { get; set; }
    }
}

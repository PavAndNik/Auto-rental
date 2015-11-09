
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRental.Model
{
    public class Characteristic : BusinesObject
    {
        public override object Clone()
        {
            return new Characteristic
            {
                Id = this.Id,
                Name = this.Name
            };
        }
    }
}

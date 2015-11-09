using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRental.Model
{
    class CommonInformation : BusinesObject
    {
        public override object Clone()
        {
            return new CommonInformation
            {
                Id = this.Id,
                Name = this.Name
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRental.Model
{
    class CommonInformation
    {
        public int NumberOfProduct { get; set; }
        public int NumberOfRentalProduct { get; set; }
        public int NumberOfFreeProduct { get; set; }
        public int NumberOfOrder { get; set; }
        public Decimal Profit  { get; set; }
    }
}

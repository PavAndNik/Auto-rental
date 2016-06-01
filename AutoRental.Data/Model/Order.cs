using AutoRental.Data.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRental.Data.Model
{
   public class Order:BaseModel
    {
 
        public Decimal FullPrice { get; set; }

        public int BuyerId { get; set; }

        public DateTime DateOfOrder { get; set; }
    }
}

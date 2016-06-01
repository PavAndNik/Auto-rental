using AutoRental.Data.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRental.Data.Model
{
    public class Product:BaseModel
    {
        enum ProductType { Auto, Trailer };

        public String Name { get; set; }

        public DateTime DateOfCreation { get; set; }

        public int Cost { get; set; }

        public string Type { get; set; }

        public string Producer { get; set; }

        public int Discount { get; set; }

        public Decimal Price { get; set; }

    }
}

﻿using AutoRental.Data.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRental.Data.Model
{
    public class ProductValueCharacteristic:BaseModel
    {
        public int CharacteristicId { get; set; }

        public virtual Characteristic Characteristic { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public String Value { get; set; }
    }
}

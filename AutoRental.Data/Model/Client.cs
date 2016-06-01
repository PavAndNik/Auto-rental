using AutoRental.Data.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRental.Data.Model
{
    public class Client:User
    {
        public string DriverLicenseNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string PassportNumber { get; set; }

    }
}

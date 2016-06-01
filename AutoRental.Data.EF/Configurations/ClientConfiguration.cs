using AutoRental.Data.EF.Configurations.Common;
using AutoRental.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRental.Data.EF.Configurations
{
    public class ClientConfiguration: BaseModelConfiguration<Client>
    {
        public ClientConfiguration()
        {
            Property(p => p.Login).HasMaxLength(50).IsRequired();
            Property(p => p.Name).HasMaxLength(50).IsRequired();
            Property(p => p.PassportNumber).IsRequired();
            Property(p => p.Surname).HasMaxLength(50).IsRequired();
            Property(p => p.PhoneNumber).IsRequired();
            Property(p => p.Password).IsRequired();
            Property(p => p.DriverLicenseNumber).IsRequired();
            Property(p => p.Email).IsRequired();
            Property(p => p.DateOfBirth).IsRequired();
        }
    }
}

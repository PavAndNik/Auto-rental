using AutoRental.Data.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRental.Data.Model.Common
{
    public class User:BaseModel
    {
        public string Name { get; set;}
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Surname { get; set; }
        public bool IsAdmin { get; }
        public Role UserRole { get; }
    }
}

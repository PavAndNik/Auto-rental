using AutoRental.Resources.Entities;
using AutoRental.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoRental.Clients.Web.Models.Clients
{
    public class ClientModel
    {
        public int Id { get; set; }

        [RegularExpression(@"^[A-Z][a-z]*$", ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "InvalidName")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(ClientDisplayNames), Name = "Name")]
        [StringLength(50, MinimumLength = 3, ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "StringLength")]
        public string Name { get; set; }

        [Display(ResourceType = typeof(ClientDisplayNames), Name = "Login")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [StringLength(20, MinimumLength = 3, ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "StringLength")]
        public string Login { get; set; }

        [Display(ResourceType = typeof(ClientDisplayNames), Name = "Password")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        public string Password { get; set; }

        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"
        , ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "InvalidEmail")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(ClientDisplayNames), Name = "Email")]
        public string Email { get; set; }

        [Display(ResourceType = typeof(ClientDisplayNames), Name = "DateOfBirth")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        public DateTime DateOfBirth { get; set; }

        [RegularExpression(@"^[A-Z][a-z]*$", ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "InvalidSurname")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(ClientDisplayNames), Name = "Surname")]
        [StringLength(50, MinimumLength = 3, ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "StringLength")]
        public string Surname { get; set; }

        [RegularExpression(@"^[0-9][A-Z]{2}[0-9]{6}$",
    ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "InvalidDriver")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(ClientDisplayNames), Name = "DriverLicenseNumber")]
        public string DriverLicenseNumber { get; set; }

        [RegularExpression(@"^375(29|33|44|25|17)[0-9]{7}$",
     ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "InvalidPhone")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(ClientDisplayNames), Name = "PhoneNumber")]
        public string PhoneNumber { get; set; }

        [RegularExpression(@"^[A-Z]{2}[0-9]{7}$",
       ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "InvalidPassport")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(ClientDisplayNames), Name = "PassportNumber")]
        public string PassportNumber { get; set; }
    }
}
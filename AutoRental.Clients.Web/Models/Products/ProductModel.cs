using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AutoRental.Resources;
using AutoRental.Resources.Entities;

namespace AutoRental.Clients.Web.Models.Products
{
    public class ProductModel
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(ProductDisplayNames), Name = "Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "StringLength")]
        public String Name { get; set; }

        [Display(ResourceType = typeof(ProductDisplayNames), Name = "DateOfCreation")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        public DateTime DateOfCreation { get; set; }

        [Display(ResourceType = typeof(ProductDisplayNames), Name = "Cost")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        public int Cost { get; set; }

        [RegularExpression(@"^[A-Z][a-z]*$", ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "InvalidType")]
        [Display(ResourceType = typeof(ProductDisplayNames), Name = "Type")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [StringLength(50, MinimumLength = 2, ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "StringLength")]
        public string Type { get; set; }

        [RegularExpression(@"^[A-Z][a-z]*$", ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "InvalidProducer")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(ProductDisplayNames), Name = "Producer")]
        [StringLength(50, MinimumLength = 2, ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "StringLength")]
        public string Producer { get; set; }

        [Display(ResourceType = typeof(ProductDisplayNames), Name = "Discount")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        public int Discount { get; set; }

        [Display(ResourceType = typeof(ProductDisplayNames), Name = "Price")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        public Decimal Price { get; set; }
    }
}
using AutoRental.Resources;
using AutoRental.Resources.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoRental.Clients.Web.Models.Characteristic
{
    public class CharacteristicModel
    {
        public int Id { get; set; }

        [Display(ResourceType = typeof(CharacteristicDisplayNames), Name = "Value")]
        [Required(ErrorMessageResourceType = typeof(Validation), ErrorMessageResourceName = "Required")]
        public String Value { get; set; }
    }
}
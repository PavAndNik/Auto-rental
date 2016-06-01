using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoRental.Clients.Web.Models.Characteristic
{
    public class CharacteristicValueModel
    {
        public int Id { get; set; }

        public int CharacteristicId { get; set; }

        public IEnumerable<SelectListItem> Characteristics { get; set; }

        [RegularExpression(@"^[A-Z][a-z]*$",
        ErrorMessage = "Invalid name. Example Characteristic.")]
        [Required]
        public String Value { get; set; }
    }
}
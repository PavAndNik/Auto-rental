using AutoRental.Clients.Web.Models.Characteristic;
using AutoRental.Data.EF;
using AutoRental.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoRental.Clients.Web.Controllers.CharacteristicValue
{
    public class CharacteristicsValueController : Controller
    {
        private readonly ServicesProductCharacteristicAsync characteristicService;
        private readonly ServicesProductValueCharacteristicAsync characteristicValueService;
        public CharacteristicsValueController()
        {
            this.characteristicService = new ServicesProductCharacteristicAsync(new ProductCharacteristicRepository(new DataContext("defaultconnection")));
            this.characteristicValueService = new ServicesProductValueCharacteristicAsync(new ProductValueCharacteristicRepository(new DataContext("defaultconnection")));

        }

        [HttpGet]
        [ActionName("Index")]

        public ActionResult Get(int id)
        {
            var characteristics = characteristicService.GetAsync().Result
                .Select(item => new SelectListItem
                {
                    Text = item.Value,
                    Value = item.Id.ToString() ,
                    Selected = true                   
                });
            var characteristic = this.characteristicValueService.GetByProductId(id).Result
                .Select(item => new CharacteristicValueModel
                {
                    Characteristics = characteristicService.GetAsync().Result
                .Select(c => new SelectListItem
                {
                    Text = item.Value,
                    Value = item.Id.ToString(),
                    Selected = item.CharacteristicId == c.Id
                }),

                })
                .ToList();

            return View("Update", characteristics);
        }
    }
}
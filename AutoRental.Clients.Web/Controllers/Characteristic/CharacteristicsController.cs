using AutoRental.Clients.Web.Models.Characteristic;
using AutoRental.Data.EF;
using AutoRental.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AutoRental.Clients.Web.Controllers.Characteristic
{
    public class CharacteristicsController : Controller
    {
        private readonly ServicesProductCharacteristicAsync characteristicService;

        public CharacteristicsController()
        {
            this.characteristicService = new ServicesProductCharacteristicAsync(new ProductCharacteristicRepository(new DataContext("defaultconnection")));
        }

        [HttpGet]
        [ActionName("Index")]
        public ActionResult Get()
        {
            var characteristic = this.characteristicService.GetAsync()
                .Result
                .Select(r => new CharacteristicModel
                {
                    Id = r.Id,
                    Value=r.Value
                });

            return View("Get", characteristic);
        }

        [HttpGet]
        public ActionResult New(CharacteristicModel model)
        {
            return View(model);
        }

        [HttpPost]
        [ActionName("Index")]
        public async Task<ActionResult> SaveNew(CharacteristicModel model)
        {
            if (!ModelState.IsValid)
            {
                return New(model);
            }

            var newCharacteristic = await this.characteristicService.AddAsync(new Data.Model.Characteristic
            {
                Value=model.Value
            });

            if (newCharacteristic == null)
            {
                ModelState.AddModelError("form", "Не удалось добавить характеристику.");
                return New(model);
            }

            return RedirectToAction("Index");
        }
    }
}
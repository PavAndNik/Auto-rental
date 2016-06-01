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
    public class CharacteristicController : Controller
    {
        private readonly ServicesProductCharacteristicAsync characteristicService;

        public CharacteristicController()
        {
            this.characteristicService = new ServicesProductCharacteristicAsync(new ProductCharacteristicRepository(new DataContext("defaultconnection")));
        }

        [HttpGet]
        [ActionName("Index")]

        public ActionResult Get(int id)
        {
            var characteristic = this.characteristicService.GetAsync(id).Result;

            if (characteristic == null)

            {
                return HttpNotFound();
            }

            var model = new CharacteristicModel

            {
                Id = characteristic.Id,
                Value=characteristic.Value
            };
            return View("Update", model);
        }

        [HttpPut]
        [ActionName("Index")]
        public async Task<ActionResult> Update(CharacteristicModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", model);
            }

            var newCharacteristic = await this.characteristicService.UpdateAsync(new Data.Model.Characteristic
            {
                Value=model.Value,

                Id = model.Id
            });

            if (newCharacteristic == null)
            {
                ModelState.AddModelError("form", "Failed to save the new characteristic.");
                return View("Update", model);
            }

            return RedirectToAction("Index", "Characteristics");
        }


        [HttpDelete]

        [ActionName("Index")]
        public async Task<ActionResult> Delete(int id)
        {

            await this.characteristicService.DeleteAsync(id);
            return RedirectToAction("Index", "Characteristics");
        }
    }
}
using AutoRental.Clients.Web.Models.Clients;
using AutoRental.Data.EF;
using AutoRental.Data.Model;
using Services.Services_Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AutoRental.Clients.Web.Controllers.Clients
{
    public class ClientController : Controller
    {
     
        private readonly ServicesClientAsync clientService;

        public ClientController()
        {
            this.clientService = new ServicesClientAsync(new ClientRepository(new DataContext("defaultconnection")));
        }

        [HttpGet]
	        [ActionName("Index")]
	
	        public ActionResult Get(int id)
	        {
	            var client = this.clientService.GetAsync(id).Result;
	
	            if (client == null)
	
	            {
	                return HttpNotFound();
	            }
	
	            var model = new ClientModel
	
	            {
                    Id = client.Id,
                    Name = client.Name,
                    Login = client.Login,
                    Password = client.Password,
                    Email = client.Email,
                    DateOfBirth = client.DateOfBirth,
                    Surname = client.Surname,
                    DriverLicenseNumber = client.DriverLicenseNumber,
                    PhoneNumber = client.PhoneNumber,
                    PassportNumber = client.PassportNumber
                };
	            return View("Update", model);
	        }
	
	        [HttpPut]
	        [ActionName("Index")]
	        public async Task<ActionResult> Update(ClientModel model)
	        {
	            if (!ModelState.IsValid)
	            {
	                return View("Update", model);
	            }
	
	            var newClient = await this.clientService.UpdateAsync(new Client
	            {
                    Name = model.Name,
                    Login = model.Login,
                    Password = model.Password,
                    Email = model.Email,
                    DateOfBirth = model.DateOfBirth,
                    Surname = model.Surname,
                    DriverLicenseNumber = model.DriverLicenseNumber,
                    PhoneNumber = model.PhoneNumber,
                    PassportNumber = model.PassportNumber,

                  Id = model.Id
              });
	
	            if (newClient == null)
	            {
	                ModelState.AddModelError("form", "Не удалось сохранить нового пользователя.");
	                return View("Update", model);
	            }
	
	            return RedirectToAction("Index", "Clients");
	        }
	
	
	        [HttpDelete]
	
	        [ActionName("Index")]
	        public async Task<ActionResult> Delete(int id)
	        {
	
	            await this.clientService.DeleteAsync(id);
	            return RedirectToAction("Index", "Clients");
	        }
		}
    }

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
    public class ClientsController : Controller
    {
        private readonly ServicesClientAsync clientService;

        public ClientsController()
        {
            this.clientService = new ServicesClientAsync(new ClientRepository(new DataContext("defaultconnection")));
        }

        //
        // GET: /Clients/
        [HttpGet]
        [ActionName("Index")]
        public ActionResult Get()
        {
            var clients = this.clientService.GetAsync()
                .Result
                .Select(r => new ClientModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Login = r.Login,
                    Password = r.Password,
                    Email = r.Email,
                    DateOfBirth = r.DateOfBirth,
                    Surname = r.Surname,
                    DriverLicenseNumber = r.DriverLicenseNumber,
                    PhoneNumber = r.PhoneNumber,
                    PassportNumber = r.PassportNumber
                });

            return View("Get", clients);
        }

        [HttpGet]
        public ActionResult New(ClientModel model)
        {
            return View(model);
        }

        [HttpPost]
	        [ActionName("Index")]
	        public async Task<ActionResult> SaveNew(ClientModel model)
	        {
	            if (!ModelState.IsValid)
	            {
	                return New(model);
	            }
	
	            var newClient = await this.clientService.AddAsync(new Client
	            {
                    Name = model.Name,
                    Login = model.Login,
                    Password = model.Password,
                    Email = model.Email,
                    DateOfBirth = model.DateOfBirth,
                    Surname = model.Surname,
                    DriverLicenseNumber = model.DriverLicenseNumber,
                    PhoneNumber = model.PhoneNumber,
                    PassportNumber = model.PassportNumber
                });
	
	            if (newClient == null)
	            {
	                ModelState.AddModelError("form", "Не удалось добавить пользователя.");
	                return New(model);
	            }
	
	            return RedirectToAction("Index");
	        }
    }
}
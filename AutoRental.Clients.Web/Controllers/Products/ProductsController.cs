using AutoRental.Clients.Web.Models.Products;
using AutoRental.Data.EF;
using AutoRental.Data.Model;
using AutoRental.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AutoRental.Clients.Web.Controllers.Products
{
    public class ProductsController : Controller
    {
        private readonly ServicesProductAsync productService;

        public ProductsController()
        {
            this.productService = new ServicesProductAsync(new ProductRepository(new DataContext("defaultconnection")));
        }


        [HttpGet]
        [ActionName("Index")]
        public ActionResult Get()
        {
            var products = this.productService.GetAsync()
                .Result
                .Select(r => new ProductModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    DateOfCreation = r.DateOfCreation,
                    Cost = r.Cost,
                    Type = r.Type,
                    Producer = r.Producer,
                    Discount = r.Discount,
                    Price = r.Price
                });

            return View("Get", products);
        }

        [HttpGet]
        public ActionResult New(ProductModel model)
        {
            return View(model);
        }

        [HttpPost]
        [ActionName("Index")]
        public async Task<ActionResult> SaveNew(ProductModel model)
        {
            if (!ModelState.IsValid)
            {
                return New(model);
            }

            var newProduct = await this.productService.AddAsync(new Product
            {
                Name = model.Name,
                DateOfCreation = model.DateOfCreation,
                Cost = model.Cost,
                Type = model.Type,
                Producer = model.Producer,
                Discount = model.Discount,
                Price = model.Price
            });

            if (newProduct == null)
            {
                ModelState.AddModelError("form", "Не удалось добавить продукт.");
                return New(model);
            }

            return RedirectToAction("Index");
        }
    }
}
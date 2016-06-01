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
    public class ProductController : Controller
    {
        private readonly ServicesProductAsync productService;

        public ProductController()
        {
            this.productService = new ServicesProductAsync(new ProductRepository(new DataContext("defaultconnection")));
        }

        [HttpGet]
        [ActionName("Index")]

        public ActionResult Get(int id)
        {
            var product = this.productService.GetAsync(id).Result;

            if (product == null)

            {
                return HttpNotFound();
            }

            var model = new ProductModel

            {
                Id = product.Id,
                Name = product.Name,
                DateOfCreation = product.DateOfCreation,
                Cost = product.Cost,
                Type = product.Type,
                Producer = product.Producer,
                Discount = product.Discount,
                Price = product.Price
            };
            return View("Update", model);
        }

        [HttpPut]
        [ActionName("Index")]
        public async Task<ActionResult> Update(ProductModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", model);
            }

            var newProduct = await this.productService.UpdateAsync(new Product
            {
                Name = model.Name,
                DateOfCreation = model.DateOfCreation,
                Cost = model.Cost,
                Type = model.Type,
                Producer = model.Producer,
                Discount = model.Discount,
                Price = model.Price,

                Id = model.Id
            });

            if (newProduct == null)
            {
                ModelState.AddModelError("form", "Не удалось сохранить новый продукт.");
                return View("Update", model);
            }

            return RedirectToAction("Index", "Products");
        }


        [HttpDelete]

        [ActionName("Index")]
        public async Task<ActionResult> Delete(int id)
        {

            await this.productService.DeleteAsync(id);
            return RedirectToAction("Index", "Products");
        }
    }
}
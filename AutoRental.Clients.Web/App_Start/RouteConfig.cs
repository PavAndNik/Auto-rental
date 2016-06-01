using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AutoRental.Clients.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                 name: "Default",
                 url: "{controller}",
                  defaults: new { controller = "Home", action = "Index" });


            routes.MapRoute(
                  name: "New",
                  url: "{controller}/new",
                  defaults: new { controller = "Clients", action = "New" });

            routes.MapRoute(
                 name: "Clients",
                 url: "{controller}",
                  defaults: new { controller = "Clients", action = "Index" });

            routes.MapRoute(
                  name: "Item",
                  url: "Clients/{id}",
                  defaults: new { controller = "Client", action = "Index" });

            routes.MapRoute(
                name: "Products",
                url: "{controller}",
                 defaults: new { controller = "Products", action = "Index" });

            routes.MapRoute(
                 name: "NewProduct",
                 url: "{controller}/new",
                 defaults: new { controller = "Products", action = "New" });

            routes.MapRoute(
                  name: "ItemProduct",
                  url: "Products/{id}",
                  defaults: new { controller = "Product", action = "Index" });

            routes.MapRoute(
                  name: "ItemProductCharacteristic",
                  url: "Products/{id}/Characteristics/{idCharacteristics}",
                  defaults: new { controller = "CharacteristicsValue", action = "Index" });

            routes.MapRoute(
                name: "Characteristics",
                url: "{controller}",
                 defaults: new { controller = "Characteristics", action = "Index" });

            routes.MapRoute(
                 name: "NewCharacteristic",
                 url: "{controller}/new",
                 defaults: new { controller = "Characteristics", action = "New" });

            routes.MapRoute(
                  name: "ItemCharacteristic",
                  url: "Characteristics/{id}",
                  defaults: new { controller = "Characteristic", action = "Index" });

        }
    }
}

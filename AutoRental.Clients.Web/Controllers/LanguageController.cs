﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace AutoRental.Clients.Web.Controllers
{
    public class LanguageController : Controller
    {
        private static readonly CultureInfo[] Culturies = {
            new CultureInfo("ru-RU"),
            new CultureInfo("en-US"),
        }; 

        [HttpGet]
        [ActionName("Index")]
        public ActionResult Get()
        {
            var model = Culturies
                .Select(ci => new SelectListItem
                {
                    Value = ci.Name,
                    Text = ci.DisplayName,
                    Selected = ci.Equals(Thread.CurrentThread.CurrentCulture)
                })
                .ToList();

            return PartialView("Get", model);
        }

        [HttpPut]
        [ActionName("Index")]
        public ActionResult Put(string culture)
        {
            Response.Cookies.Add(new HttpCookie("culture", culture));

            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }
    }
}
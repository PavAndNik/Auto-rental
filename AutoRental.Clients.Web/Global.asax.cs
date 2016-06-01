using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AutoRental.Clients.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        void Application_BeginRequest(object sender, EventArgs e)
        {
            var cultureCookie = Request.Cookies.Get("culture");
            if (cultureCookie == null)
            {
                return;
            }

            Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureCookie.Value);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureCookie.Value);
        }
    }
}

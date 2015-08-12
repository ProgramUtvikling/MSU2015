using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ImdbWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
			ViewEngines.Engines.Clear();
			ViewEngines.Engines.Add(new RazorViewEngine());

			BundleConfig.RegisterBundles(BundleTable.Bundles);
			FilterConfig.RegisterFilters(GlobalFilters.Filters);
            AreaRegistration.RegisterAllAreas();
			RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ImdbWeb
{
    public class FilterConfig
    {
        public static void RegisterFilters(GlobalFilterCollection filters)
        {
			filters.Add(new HandleErrorAttribute());
			//filters.Add(new AuthorizeAttribute());
		}
    }
}

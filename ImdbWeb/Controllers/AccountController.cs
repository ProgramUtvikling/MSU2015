using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ImdbWeb.Controllers
{
    public class AccountController : Controller
    {
		[HttpGet]
		[AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

		[HttpPost]
		[AllowAnonymous]
		public ActionResult Login(string username, string password)
		{
			if(username == "arjan" && password == "pass")
			{
				FormsAuthentication.SetAuthCookie(username, false);
				return RedirectToAction("Index", "Home");
			}

			return View();
		}

		public ActionResult SignOut()
		{
			FormsAuthentication.SignOut();
			return RedirectToAction("Index", "Home");
		}
	}
}
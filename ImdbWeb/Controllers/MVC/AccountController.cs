using ImdbWeb.Models.AccountModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ImdbWeb.Controllers.MVC
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
		[ValidateAntiForgeryToken]
		[AllowAnonymous]
		public ActionResult Login(LoginModel model, string returnUrl)
		{
			if (ModelState.IsValid)
			{

				if (model.Username == "arjan" && model.Password == "pass")
				{
					FormsAuthentication.SetAuthCookie(model.Username, model.RememberMe);
					if (string.IsNullOrWhiteSpace(returnUrl))
					{
						return RedirectToAction("Index", "Home");
					}
					return Redirect(returnUrl);
				}

			}
			return View();
		}

		public ActionResult SignOut()
		{
			FormsAuthentication.SignOut();
			return RedirectToAction("Index", "Home");
		}

		[ChildActionOnly]
		public ActionResult LoginStatus()
		{
			if (Request.IsAuthenticated)
			{
				ViewData.Model = User.Identity.Name;
				return PartialView("Authenticated");
			}

			return PartialView("NotAuthenticated");
		}
	}
}
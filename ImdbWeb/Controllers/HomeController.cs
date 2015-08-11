using ImdbWeb.Models.HomeModels;
using Microsoft.Security.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImdbWeb.Controllers
{
	public class HomeController : Controller
	{
		public ViewResult Index()
		{
			return View();
		}

		public ViewResult Demo()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Demo(DemoModel model)
		{
			model.Artikkel = Sanitizer.GetSafeHtmlFragment(model.Artikkel);

			ViewData.Model = model;
			if (Request.IsAjaxRequest())
			{
				return PartialView("DemoResult");
			}
			return View("DemoResult");
		}

	}
}
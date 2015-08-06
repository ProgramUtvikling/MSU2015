using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ImdbWeb.Controllers
{
	public class ImageController : Controller
	{
		[Route("Image/{format}/{id}.jpg")]
		public ActionResult CreateImage(string format, string id)
		{
			string relPath = $"~/App_Data/covers/{id}.jpg";
			string absPath = Server.MapPath(relPath);

			if (!System.IO.File.Exists(absPath)) return HttpNotFound();

			var img = new WebImage(absPath);

			switch (format.ToLower())
			{
				case "thumb":
					img.Resize(100, 1000)
						.Write();
					return new EmptyResult();

				case "medium":
					img.Resize(300, 3000)
						.AddTextWatermark("Ingars Movie Database")
						.AddTextWatermark("Ingars Movie Database", "White", padding: 7)
						.Write();
					return new EmptyResult();

				default:
					return HttpNotFound();
			}
		}
	}
}
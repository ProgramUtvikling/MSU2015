using MovieDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImdbWeb.Controllers
{
	[RoutePrefix("Movie")]
	public class MovieController : ImdbControllerBase
	{
		[OutputCache(CacheProfile="short")]
		public ActionResult Index()
		{
			ViewData.Model = Db.Movies;
			return View();
		}

		public ActionResult Genres()
		{
			ViewData.Model = Db.Genres;
			return View();
		}

		[Route("Genre/{genrename}")]
		public ActionResult MoviesByGenre(string genrename)
		{
			ViewData.Model = Db.Movies.Where(m => m.Genre.Name == genrename);
			ViewBag.Sjanger = genrename;

			return View("Index");
		}

		public ActionResult Details(string id)
		{
			var movie = Db.Movies.Find(id);
			if (movie == null) return HttpNotFound();


			ViewData.Model = movie;

			return View();
		}
	}
}
using MovieDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImdbWeb.Controllers
{
	[RoutePrefix("Movie")]
    public class MovieController : Controller
    {
		private ImdbContext Db = new MovieDAL.ImdbContext();

		public ViewResult Index()
		{
			ViewData.Model = Db.Movies;
			return View();
		}

		public ViewResult Genres()
		{
			ViewData.Model = Db.Genres;
			return View();
		}

		[Route("Genre/{genrename}")]
		public ViewResult MoviesByGenre(string genrename)
		{
			ViewData.Model = Db.Movies.Where(m => m.Genre.Name == genrename);
			return View("Index");
		}

		public ViewResult Details(string id)
		{
			var movie = Db.Movies.Find(id);
			ViewData.Model = movie;

			return View();
		}
	}
}
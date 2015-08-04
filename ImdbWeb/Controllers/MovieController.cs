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
		public ViewResult Index()
		{
			var db = new MovieDAL.ImdbContext();
			ViewData.Model = db.Movies;

			return View();
		}

		public string Genres()
		{
			return "MovieController.Genres";
		}

		[Route("Genre/{genrename}")]
		public string MoviesByGenre(string genrename)
		{
			return $"MovieController.MoviesByGenre({genrename})";
		}

		public ViewResult Details(string id)
		{
			var db = new MovieDAL.ImdbContext();

			var movie = db.Movies.Find(id);
			ViewData.Model = movie;

			return View();
		}

	}
}
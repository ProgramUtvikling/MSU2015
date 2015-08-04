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
		public string Index()
		{
			return "MovieController.Index";
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

		public string Details(string id)
		{
			//return string.Format("MovieController.Details({0})", id);
			return $"MovieController.Details({id})";
		}

	}
}
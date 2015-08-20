using MovieDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace ImdbWeb.Controllers.MVC
{
    public class ImdbApiController : ImdbControllerBase
    {
		public ActionResult Movies(string fmt = "xml")
		{
			switch (fmt.ToLower())
			{
				case "xml": return MoviesAsXml();
				case "json": return MoviesAsJson();
				default:
					return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
		}

		private ActionResult MoviesAsJson()
		{
			var doc = from movie in Db.Movies
					  select new { id = movie.MovieId, title = movie.Title };

			return Json(doc, JsonRequestBehavior.AllowGet);
		}

		private ActionResult MoviesAsXml()
        {
			var movies = Db.Movies.ToList();

			var doc = new XElement("movies",
									from movie in movies
									select new XElement("movie",
										new XAttribute("id", movie.MovieId),
										movie.Title));

			return Content(doc.ToString(), "application/xml");
        }

		[Route("Movie/Details/{id}.xml")]
		public ActionResult MovieDetails(string id)
		{
			var movie = Db.Movies.Find(id);
			if (movie == null) return HttpNotFound();

			var doc = new XElement("movie",
				new XAttribute("id", movie.MovieId),
				new XAttribute("title", movie.Title),
				new XAttribute("origTitle", movie.OriginalTitle),
				new XAttribute("runLen", movie.RunningLength),
				from person in movie.Producers select new XElement("producer", person.Name),
				from person in movie.Directors select new XElement("director", person.Name),
				from person in movie.Actors select new XElement("actor", person.Name),
				new XCData(movie.Description)
				);

			return Content(doc.ToString(), "application/xml");
		}
	}
}
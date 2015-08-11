using MovieDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
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

		public async Task<ActionResult> Genres()
		{
			ViewData.Model = await Db.Genres.ToListAsync();
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

			if (Request.IsAjaxRequest())
			{
				return PartialView();
			}
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Commenting(string id, string author, string headline, string body)
		{
			var movie = Db.Movies.Find(id);
			if (movie == null) return HttpNotFound();

			var comment = new Comment { Author = author, Headline = headline, Body = body };
			movie.Comments.Add(comment);
			await Db.SaveChangesAsync();
			await Task.Delay(3000);

			ViewData.Model = comment;

			if (Request.IsAjaxRequest())
			{
				return PartialView("Comment");
			}
			return RedirectToAction("Details", "Movie", new { id });
		}
	}
}
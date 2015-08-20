using ImdbWeb.Models;
using ImdbWeb.Models.RatingModels;
using MovieDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ImdbWeb.Controllers.MVC
{
	public class RatingController : ImdbControllerBase
	{
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Vote(string movieId, int vote)
		{
			var movie = Db.Movies.Find(movieId);
			if (movie == null) return HttpNotFound();

			if (vote < 1 || vote > 5)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			movie.Ratings.Add(new Rating { Vote = vote });
			await Db.SaveChangesAsync();

			ViewData.Model = new VoteResultModel()
			{
				MovieId = movieId,
				YourVote = vote,
				AverageVote = movie.Ratings.Average(r => r.Vote),
				VoteCount = movie.Ratings.Count()
			};

			if (Request.IsAjaxRequest())
			{
				return PartialView("_VoteResult");
			}
			return View("VoteResult");
		}
	}
}
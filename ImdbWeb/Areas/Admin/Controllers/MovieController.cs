
using ImdbWeb.Areas.Admin.Models.MovieModels;
using ImdbWeb.Controllers;
using MovieDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ImdbWeb.Areas.Admin.Controllers
{
	[Authorize]
	public class MovieController : ImdbControllerBase
	{
		// GET: Admin/Movie
		public ActionResult Index()
		{
			ViewData.Model = Db.Movies.Select(m => new MovieIndexModel
			{
				Id = m.MovieId,
				Title = m.Title,
				RunningLength = m.RunningLength
			});

			return View();
		}

		public ActionResult Create()
		{
			ViewBag.Genres = new SelectList(Db.Genres, "GenreId", "Name");
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(MovieCreateModel model)
		{
			if (ModelState.IsValid)
			{
				var movie = new Movie
				{
					MovieId = model.Id,
					Title = model.Title,
					OriginalTitle = model.Title,
					Description = model.Description,
					ProductionYear = model.ProductionYear,
					RunningLength = model.RunningLength_Hours * 60 + model.RunningLength_Minutes,
					Genre = Db.Genres.Find(model.GenreId)
				};

				Db.Movies.Add(movie);
				await Db.SaveChangesAsync();

				return RedirectToAction("Index");
			}

			return Create();
		}

		public static ValidationResult CheckIdLocal(string movieId)
		{
			var db = new ImdbContext();
			if(db.Movies.Any(m => m.MovieId == movieId))
			{
				return new ValidationResult("Filmen er allerede registrert (local)");
			}
			return ValidationResult.Success;
		}

		[HttpPost]
		public JsonResult CheckIdRemote(string id)
		{
			if (Db.Movies.Any(m => m.MovieId == id))
			{
				return Json("Filmen er allerede registrert (remote)");
			}
			return Json(true);
		}

		public ActionResult Delete(string id)
		{
			var movie = Db.Movies.Find(id);
			if (movie == null) return HttpNotFound();

			ViewData.Model = new MovieDeleteModel {
				Id = movie.MovieId,
				Title = movie.Title,
				ProductionYear = movie.ProductionYear
			};
			return View();
		}

		[HttpDelete]
		[ValidateAntiForgeryToken]
		[ActionName("Delete")]
		public async Task<ActionResult> DeleteConfirmed(string id)
		{
			var movie = Db.Movies.Find(id);
			if (movie == null) return HttpNotFound();

			Db.Movies.Remove(movie);
			await Db.SaveChangesAsync();

			return RedirectToAction("Index");
		}
	}
}
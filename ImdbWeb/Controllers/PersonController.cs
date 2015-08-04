using MovieDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImdbWeb.Controllers
{
    public class PersonController : Controller
    {
		private ImdbContext Db = new MovieDAL.ImdbContext();

		public ViewResult Actors()
		{
			ViewData.Model = from p in Db.Persons
							 where p.ActedMovies.Any()
							 select p;

			return View("Index");
		}
		public ViewResult Producers()
		{
			ViewData.Model = from p in Db.Persons
							 where p.ProducedMovies.Any()
							 select p;

			return View("Index");
		}
		public ViewResult Directors()
		{
			ViewData.Model = from p in Db.Persons
							 where p.DirectedMovies.Any()
							 select p;

			return View("Index");
		}

		[Route("Person/{id:int}")]
		public ViewResult Details(int id)
		{
			var person = Db.Persons.Find(id);

			ViewData.Model = person;

			return View();
		}

	}
}
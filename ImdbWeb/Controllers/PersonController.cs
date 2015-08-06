using ImdbWeb.Models.PersonModels;
using MovieDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImdbWeb.Controllers
{
	public class PersonController : ImdbControllerBase
	{
		public ViewResult Actors()
		{
			var persons = from p in Db.Persons
						  where p.ActedMovies.Any()
						  select p;

			ViewData.Model = new PersonIndexModel
			{
				Persons = persons,
				Title = "Skuespillere"
			};
			return View("Index");
		}
		public ViewResult Producers()
		{
			var persons = from p in Db.Persons
						  where p.ProducedMovies.Any()
						  select p;

			ViewData.Model = new PersonIndexModel
			{
				Persons = persons,
				Title = "Produsenter"
			};

			return View("Index");
		}
		public ViewResult Directors()
		{
			var persons = from p in Db.Persons
						  where p.DirectedMovies.Any()
						  select p;

			ViewData.Model = new PersonIndexModel
			{
				Persons = persons,
				Title = "Regisører"
			};

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
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using MovieDAL;
using System.Data.Entity;
using MovieImporter.filmerDataSetTableAdapters;
using MovieDAL.Migrations;

namespace MovieImporter
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Starting import");
			var sw = Stopwatch.StartNew();
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<ImdbContext, Configuration>());

			var db = new ImdbContext();
			if (!db.Persons.Any())
			{
				Load(db);
				Console.WriteLine("{0} movies and {1} persons imported (duration: {2})",
					db.Movies.Count(), db.Persons.Count(), sw.Elapsed);
			}

			//DownloadCoverImages();

			Console.WriteLine("Press ENTER...");
			Console.ReadLine();
		}

		private static void DownloadCoverImages()
		{
			Console.WriteLine("Downloading cover images");
			string path = @"C:\Users\ProgramUtvikling\Documents\MovieCovers";
			using (var db = new ImdbContext())
			{
				foreach (var movie in db.Movies)
				{
					try
					{
						var req = WebRequest.Create("http://hemmelignummeroghemmeligadres.se/" + movie.MovieId + ".jpg");
						var response = req.GetResponse();
						string filename = Path.Combine(path, movie.MovieId + ".jpg");
						using (var fs = new FileStream(filename, FileMode.Create))
						{
							response.GetResponseStream().CopyTo(fs);
						}
						Console.Write(".");

					}
					catch (Exception)
					{
						Console.WriteLine("e");
					}
				}
			}
		}

		private static void Load(ImdbContext db)
		{
			Console.WriteLine("Starting to seed database...");
			Console.WriteLine("Loading from Access DB");
			var ds = LoadFromAccessDb();

			Console.WriteLine("Writing to SQL DB");
			foreach (var skuespiller in ds.skuespiller)
			{
				Console.Write("a");
				var actor = new Person { Name = skuespiller.navn };
				db.Persons.Add(actor);
			}

			var produsenter = ds.produsent.Select(p => p.navn);
			var skuespillere = ds.skuespiller.Select(p => p.navn);

			foreach (var navn in produsenter.Except(skuespillere))
			{
				Console.Write("p");
				var person = new Person { Name = navn };
				db.Persons.Add(person);
			}

			db.SaveChanges();
			Console.WriteLine();

			foreach (var kategori in ds.kategori)
			{
				var genre = new Genre { Name = kategori.tekst.Trim() };
				db.Genres.Add(genre);

				Console.WriteLine(kategori.tekst);
				foreach (var film in kategori.GetfilmRows())
				{
					var movie = new Movie
					{
						MovieId = film.id,
						Genre = genre,
						Description = film.kommentar,
						OriginalTitle = film.orgtittel,
						Title = film.tittel,
						ProductionYear = film.innspiltaar,
						RunningLength = film.spilletid,
						Actors = new List<Person>(),
						Producers = new List<Person>(),
						Directors = new List<Person>()
					};

					foreach (var skuespill in film.GetskuespillRows())
					{
						Console.Write("a");
						var actor = db.Persons.Single(p => p.Name == skuespill.skuespillerRow.navn);
						movie.Actors.Add(actor);
					}
					foreach (var produsert in film.GetprodusertRows())
					{
						Console.Write("p");
						var producer = db.Persons.Single(p => p.Name == produsert.produsentRow.navn);
						movie.Producers.Add(producer);
					}
					foreach (var regissert in film.GetregissertRows())
					{
						Console.Write("d");
						var director = db.Persons.Single(p => p.Name == regissert.produsentRow.navn);
						movie.Directors.Add(director);
					}

					db.Movies.Add(movie);
					Console.Write(".");
				}
				Console.WriteLine();
			}


			Console.WriteLine("Database seeded, now saving...");
			db.SaveChanges();
		}

		private static filmerDataSet LoadFromAccessDb()
		{
			var ds = new filmerDataSet();
			var filmTa = new filmTableAdapter();
			var kategoriTa = new kategoriTableAdapter();
			var skuespillTa = new skuespillTableAdapter();
			var skuespillerTa = new skuespillerTableAdapter();
			var produsertTa = new produsertTableAdapter();
			var produsentTa = new produsentTableAdapter();
			var regisertTa = new regissertTableAdapter();

			filmTa.Fill(ds.film);
			skuespillTa.Fill(ds.skuespill);
			skuespillerTa.Fill(ds.skuespiller);
			kategoriTa.Fill(ds.kategori);
			produsentTa.Fill(ds.produsent);
			produsertTa.Fill(ds.produsert);
			regisertTa.Fill(ds.regissert);
			return ds;
		}

	}
}

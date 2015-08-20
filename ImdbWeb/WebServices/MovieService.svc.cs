using MovieDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ImdbWeb.WebServices
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MovieService" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select MovieService.svc or MovieService.svc.cs at the Solution Explorer and start debugging.
	public class MovieService : IMovieService, IDisposable
	{
		public ImdbContext Db = new MovieDAL.ImdbContext();

		public void Dispose()
		{
			Db.Dispose();
		}

		public MovieCargo GetMovie(string id)
		{
			var movie = Db.Movies.Find(id);

			return new MovieCargo
			{
				Id = movie.MovieId,
				Title = movie.Title,
				ProductionYear = movie.ProductionYear
			};
		}

		public IEnumerable<MovieCargo> GetMovies()
		{
			var res = Db.Movies.Select(m => new MovieCargo
			{
				Id = m.MovieId,
				Title = m.Title,
				ProductionYear = m.ProductionYear
			});

			return res;
		}
	}
}

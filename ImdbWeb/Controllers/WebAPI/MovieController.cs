using ImdbWeb.Models.WebAPI;
using MovieDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;

namespace ImdbWeb.Controllers.WebAPI
{
    public class MovieController : ApiController
    {
		public ImdbContext Db = new MovieDAL.ImdbContext();

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				Db.Dispose();
			}

			base.Dispose(disposing);
		}

		// GET: api/Movie
		[EnableQuery]
		public IQueryable<MovieApiModel> Get()
        {
			var res = from m in Db.Movies
					  select new MovieApiModel
					  {
						  Id = m.MovieId,
						  OriginalTitle = m.OriginalTitle,
						  Title = m.Title,
						  RunningLength = m.RunningLength
					  };

            return res;
        }

        // GET: api/Movie/5
        public MovieApiModel Get(string id)
        {
			var movie = Db.Movies.Find(id);

            return new MovieApiModel
			{
				Id = movie.MovieId,
				OriginalTitle = movie.OriginalTitle,
				Title = movie.Title,
				RunningLength = movie.RunningLength
			};
		}

        //// POST: api/Movie
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Movie/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Movie/5
        //public void Delete(int id)
        //{
        //}
    }
}

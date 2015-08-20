using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MovieDAL
{
	public class Rating
	{
		public int RatingId { get; set; }
		public int Vote { get; set; }

		public Guid? CookieIdentifier { get; set; }
		
		public Movie Movie { get; set; }
	}
}

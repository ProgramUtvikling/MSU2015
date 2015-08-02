using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDAL
{
	public class Person
	{
		public int PersonId { get; set; }
		
		[MaxLength(100)]
		public string Name { get; set; }

		public virtual ICollection<Movie> ActedMovies { get; set; }
		public virtual ICollection<Movie> ProducedMovies { get; set; }
		public virtual ICollection<Movie> DirectedMovies { get; set; }
	}
}

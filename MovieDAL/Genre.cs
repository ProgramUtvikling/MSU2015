using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDAL
{
    public class Genre
    {
		public int GenreId { get; set; }

		[MaxLength(30)]
		public string Name { get; set; }

        public virtual ICollection<Movie> Movies{get;set;}
    }
}

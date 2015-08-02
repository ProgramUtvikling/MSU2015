using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MovieDAL
{
	public class Comment
	{
		public int CommentId { get; set; }

		[MaxLength(100)]
		public string Author { get; set; }
	
		[MaxLength(100)]
		public string Headline { get; set; }

		[MaxLength(4000)]
		public string Body { get; set; }

		public Movie Movie { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ImdbWeb.Areas.Admin.Models.MovieModels
{
	public class MovieIndexModel
	{
		[Display(Name="EAN kode")]
		public string Id { get; set; }

		[Display(Name="Tittel")]
		public string Title { get; set; }

		[Display(Name="Varighet")]
		[UIHint("Duration")]
		public int RunningLength { get; set; }
	}
}
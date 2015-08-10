using ImdbWeb.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ImdbWeb.Areas.Admin.Models.MovieModels
{
	public class MovieCreateModel
	{
		[Display(Name = "EAN kode")]
		[Required]
		[StringLength(30)]
		[CustomValidation(typeof(MovieController), "CheckIdLocal")]
		public string Id { get; set; }

		[Display(Name = "Tittel")]
		[Required]
		[MaxLength(100)]
		public string Title { get; set; }

		[Display(Name = "Original tittel")]
		[MaxLength(100)]
		public string OriginalTitle { get; set; }

		[Display(Name = "Beskrivelse")]
		[DataType(DataType.MultilineText)]
		public string Description { get; set; }

		[Display(Name = "Produksjonsår")]
		[MaxLength(4)]
		public string ProductionYear { get; set; }

		[Display(Name = "Timer")]
		[Required]
		[Range(0, int.MaxValue / 60 - 1)]
		public int RunningLength_Hours { get; set; }

		[Display(Name = "Minutter")]
		[Required]
		[Range(0, 59)]
		public int RunningLength_Minutes { get; set; }

		[Display(Name = "Sjanger")]
		[Required]
		public int GenreId { get; set; }
	}
}
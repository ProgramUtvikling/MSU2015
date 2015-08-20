using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImdbShared.WebAPI
{
	public class MovieApiModel
	{
		public string Id { get; set; }
		public string Title { get; set; }
		public string OriginalTitle { get; set; }
		public int RunningLength { get; set; }
	
	}
}
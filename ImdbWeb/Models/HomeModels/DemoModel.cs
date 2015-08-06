using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImdbWeb.Models.HomeModels
{
	public class DemoModel
	{
		public string Overskrift { get; set; }

		[AllowHtml]
		public string Artikkel { get; set; }
	}
}
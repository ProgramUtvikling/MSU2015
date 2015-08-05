using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImdbWeb.Models.PersonModels
{
	public class PersonIndexModel
	{
		public IEnumerable<MovieDAL.Person> Persons { get; set; }
		public string Title { get; set; }
	}
}
using MovieDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace ImdbWeb.Helpers
{
	public static class MyHtmlHelpers
	{
		public static MvcHtmlString PrettyJoin(this HtmlHelper html, IEnumerable<Person> persons)
		{
			int count = 0;
			string res = "";

			foreach (var person in persons)
			{
				switch (++count)
				{
					case 1:
						res = html.ActionLink(person.Name, "Details", "Person", new { id = person.PersonId }, null).ToString();
						break;

					case 2:
						res = html.ActionLink(person.Name, "Details", "Person", new { id = person.PersonId }, null).ToString() + " og " + res;
						break;

					default:
						res = html.ActionLink(person.Name, "Details", "Person", new { id = person.PersonId }, null).ToString() + ", " + res;
						break;
				}
			}

			return MvcHtmlString.Create(res);
		}
	}
}
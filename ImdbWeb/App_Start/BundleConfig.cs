using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace ImdbWeb
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/allscripts")
				.Include("~/Scripts/jquery-2.1.4.js",
				"~/Scripts/jquery.unobtrusive-ajax.js",
				"~/Scripts/jquery.validate.js",
				"~/Scripts/jquery.validate.unobtrusive.js",
				"~/Scripts/popup.js")
				);
		}
	}
}
using InTravels.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InTravels.WebAPI.Controllers
{
	[Culture]
	public class BaseController : Controller
    {
		public ActionResult ChangeCulture(string lang)
		{
			string returnUrl = Request.UrlReferrer.AbsolutePath;
			List<string> cultures = new List<string>() { "en", "ru-RU", "uk-UA" }; // TODO! Replace to config file!
			if (!cultures.Contains(lang))
			{
				lang = "en";
			}
			HttpCookie cookie = Request.Cookies["lang"];
			if (cookie != null)
				cookie.Value = lang; 
			else
			{
				cookie = new HttpCookie("lang");
				cookie.HttpOnly = false;
				cookie.Value = lang;
				cookie.Expires = DateTime.Now.AddYears(1);
			}
			Response.Cookies.Add(cookie);
			return Redirect(returnUrl);
		}
	}
}
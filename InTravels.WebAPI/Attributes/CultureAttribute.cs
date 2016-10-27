using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace InTravels.Attributes
{
	public class CultureAttribute : FilterAttribute, IActionFilter
	{
		public void OnActionExecuted(ActionExecutedContext filterContext)
		{
			//не реализован
		}

		public void OnActionExecuting(ActionExecutingContext filterContext)
		{
			string cultureName = null;
			// Получаем куки из контекста, которые могут содержать установленную культуру
			HttpCookie cultureCookie = filterContext.HttpContext.Request.Cookies["lang"];
			if (cultureCookie != null)
				cultureName = cultureCookie.Value;
			else
				cultureName = "en"; //english by default

			// Список культур
			List<string> cultures = new List<string>() { "en", "ru", "uk-UA" }; // TODO! Replace to config file!
			if (!cultures.Contains(cultureName))
			{
				cultureName = "en"; //english by default
			}
			Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName);
			Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(cultureName);
		}
	}
}
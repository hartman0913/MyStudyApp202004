using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class DiaryController : Controller
    {
			// ~/Diary/{*date}
			public ActionResult Details(DateTime date) {
				Models.Class1 class1 = new Models.Class1();
				class1.Comment = "の日記";
				class1.Date = DateTime.Now;
				return View(class1);
			}

			// ~/Comment/{*date}
			public ActionResult Comment(DateTime date)
			{
				

				return View();
			}
		
	}
}
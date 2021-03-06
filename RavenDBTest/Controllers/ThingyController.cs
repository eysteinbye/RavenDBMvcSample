﻿using System.Web.Mvc;
using RavenDBTest.Model;

namespace RavenDBTest.Controllers
{
	public class ThingyController : BaseController
	{
		public ActionResult Index()
		{
			return View(RavenSession.Query<Thingy>());
		}

		public ActionResult New()
		{
			return View();
		}

		public ActionResult Create(Thingy thingy)
		{
			RavenSession.Store(thingy);

			return RedirectToAction("Index");
		}

		public ActionResult Config()
		{
			ViewBag.ApiKey = MvcApplication.Store.ApiKey;
			ViewBag.Url = MvcApplication.Store.Url;
			return View();
		}
	}
}

using System;
using System.Web.Mvc;
using Raven.Client;
using RavenDBTest.Model;

namespace RavenDBTest.Controllers
{
	public class ThingyController : Controller
	{
		private Lazy<IDocumentSession> _lazyDocumentSession = new Lazy<IDocumentSession>(() => MvcApplication.DocumentStore.OpenSession());

		private IDocumentSession DocumentSession
		{
			get
			{
				return _lazyDocumentSession.Value;
			}
		}

		public ActionResult Index()
		{
			return View(DocumentSession.Query<Thingy>());
		}

		public ActionResult New()
		{
			return View();
		}

		public ActionResult Create(Thingy thingy)
		{
			DocumentSession.Store(thingy);
			DocumentSession.SaveChanges();

			return RedirectToAction("Index");
		}
	}
}

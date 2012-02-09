using System.Web.Mvc;
using RavenDBTest.Model;
using Raven.Client;

namespace RavenDBTest.Controllers
{
	public class ThingyController : Controller
	{
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

		private IDocumentSession DocumentSession
		{
			get {
				return MvcApplication.DocumentStore.OpenSession();
			}
		}
	}
}

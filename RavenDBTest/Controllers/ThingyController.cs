using System.Linq;
using System.Web.Mvc;
using Raven.Client;
using RavenDBTest.Model;

namespace RavenDBTest.Controllers
{
	public class ThingyController : Controller
	{
		public ActionResult Index()
		{
			return View(DocumentSession.Query<Thingy>().ToList());
		}

		public ActionResult New()
		{
			return View();
		}

		public ActionResult Create(Thingy thingy)
		{
			var session = DocumentSession;
			session.Store(thingy);
			session.SaveChanges();

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

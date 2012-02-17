using System.Linq;
using System.Web.Mvc;
using RavenDBTest.Model;

namespace RavenDBTest.Controllers
{
	public class ThingyController : Controller
	{
		public ActionResult Index()
		{
			using (var session = MvcApplication.Store.OpenSession())
			{
				return View(session.Query<Thingy>());
			}
		}

		public ActionResult New()
		{
			return View();
		}

		public ActionResult Create(Thingy thingy)
		{
			using (var session = MvcApplication.Store.OpenSession())
			{
				session.Store(thingy);
				session.SaveChanges();
			}

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

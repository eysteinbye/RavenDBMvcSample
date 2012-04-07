using System.Web.Mvc;

namespace RavenDBTest.Controllers
{
	public class HomeController : BaseController
	{
		public ActionResult Index()
		{
			return View();
		}
	}
}

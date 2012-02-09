using System.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using Raven.Client.Document;

namespace RavenDBTest
{
	public class MvcApplication : System.Web.HttpApplication
	{
		public static DocumentStore DocumentStore { get; set; }

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Default", // Route name
				"{controller}/{action}/{id}", // URL with parameters
				new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
			);
		}

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			RegisterRoutes(RouteTable.Routes);

			DocumentStore = new DocumentStore { Url = "https://2.ravenhq.com/databases/AppHarbor_df299464-a728-4935-b5c7-4ac4626bdc4a",
				ApiKey = "24cee556-b25f-4701-a572-6ca9791b007a" };
			DocumentStore.Initialize();
		}
	}
}

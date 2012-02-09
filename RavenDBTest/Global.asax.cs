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

			DocumentStore = new DocumentStore { Url = ConfigurationManager.AppSettings["RAVENHQ_CONNECTION_STRING"] };
			DocumentStore.Initialize();
		}
	}
}

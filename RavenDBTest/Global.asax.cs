using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Raven.Client.Document;

namespace RavenDBTest
{
	public class MvcApplication : System.Web.HttpApplication
	{
		public static DocumentStore Store { get; set; }

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

			var connectionString = ConfigurationManager.ConnectionStrings["RavenDB"].ConnectionString;

			Store = new DocumentStore
			{
				ApiKey = connectionString.Split(';').Last().Split('=').Last(),
				Url = connectionString.Split(';').First().Split('=').Last(),
			};

			Store.Initialize();
		}
	}
}

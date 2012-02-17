using System.Web.Mvc;
using System.Web.Routing;
using Raven.Abstractions.Data;
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

			var parser = ConnectionStringParser<RavenConnectionStringOptions>.FromConnectionStringName("RavenDB");
			parser.Parse();

			Store = new DocumentStore
			{
				ApiKey = parser.ConnectionStringOptions.ApiKey,
				Url = parser.ConnectionStringOptions.Url,
			};

			Store.Initialize();
		}
	}
}

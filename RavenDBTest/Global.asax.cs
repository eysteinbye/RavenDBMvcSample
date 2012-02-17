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

			Store = new DocumentStore
			{
				ApiKey = "33f81f9a-111f-4cec-83c3-f0c4afb9a5ef",
				Url = "https://1.ravenhq.com/databases/AppHarbor_6566a44b-959e-4766-9c58-ab9000d54d49"
			};

			//{ ConnectionStringName = "RavenDB" };
			Store.Initialize();
		}
	}
}

using System;
using System.Configuration;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Commons;
using Migrations;
using WebApp.Attributes;
using WebApp.Binders;
using log4net.Config;

namespace WebApp
{
    public class MvcApplication : HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              "SampleEdit",
              "Article/{id}/R",
              new { controller = "Article", action = "Edit", validateAntiForgeryToken = true }
            );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            XmlConfigurator.Configure();

            NinjectContainerSetup.SetUp();

            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
            
            GlobalFilters.Filters.Add(new LogAttribute());

            ModelBinders.Binders[typeof(DateTime)] = new DateTimeBinder();

            MigrateDatabase();
        }

        private static void MigrateDatabase()
        {
            string connectionString = ConfigurationManager.ConnectionStrings[Constants.ConnectionStringName].ConnectionString;
            ExternallyCallableMigration.MigrateToLastVersion(Constants.DatabaseProvider, connectionString);
        }
    }
}

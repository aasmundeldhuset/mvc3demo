using System.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using BusinessLogic;
using Commons;
using Domain;
using Migrations;
using Ninject;
using Ninject.Web.Mvc;
using WebApp.Attributes;
using log4net.Config;

namespace WebApp
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : NinjectHttpApplication
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

        protected override void OnApplicationStarted()
        {
            XmlConfigurator.Configure();
            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);
            // Register global filter
            GlobalFilters.Filters.Add(new LogAttribute());

            MigrateDatabase();
        }

        protected override IKernel CreateKernel()
        {
            return new StandardKernel(new RepoModule(), new LogicModule());
        }

        private static void MigrateDatabase()
        {
            string connectionString = ConfigurationManager.ConnectionStrings[Constants.ConnectionStringName].ConnectionString;
            ExternallyCallableMigration.MigrateToLastVersion(Constants.DatabaseProvider, connectionString);
        }
    }
}
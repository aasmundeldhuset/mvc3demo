using System.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using Commons;
using Domain;
using Migrations;
using Ninject;
using Ninject.Web.Mvc;

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
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected override void OnApplicationStarted()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);
            MigrateDatabase();
        }

        protected override IKernel CreateKernel()
        {
            return new StandardKernel(new RepoModule());
        }

        private static void MigrateDatabase()
        {
            string connectionString = ConfigurationManager.ConnectionStrings[Constants.ConnectionStringName].ConnectionString;
            ExternallyCallableMigration.MigrateToLastVersion(Constants.DatabaseProvider, connectionString);
        }
    }
}
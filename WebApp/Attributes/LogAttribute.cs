using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;

namespace WebApp.Attributes
{
    public class LogAttribute : ActionFilterAttribute
    {
        private log4net.ILog _log = LogManager.GetLogger(typeof (LogAttribute));

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var authenticated = filterContext.HttpContext.User.Identity.IsAuthenticated;
            var name = filterContext.HttpContext.User.Identity.Name;
            var route = filterContext.RouteData.Route.ToString();

            _log.Info((authenticated ? "Æn uatorisert bruker" : name) + " sa: 'Æ vil ha " + filterContext.HttpContext.Request.RawUrl + "'");
        }


    }
}
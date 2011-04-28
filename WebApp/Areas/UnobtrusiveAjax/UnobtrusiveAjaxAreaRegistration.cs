using System.Web.Mvc;

namespace WebApp.Areas.UnobtrusiveAjax
{
    public class UnobtrusiveAjaxAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "UnobtrusiveAjax";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "UnobtrusiveAjax_default",
                "UnobtrusiveAjax/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

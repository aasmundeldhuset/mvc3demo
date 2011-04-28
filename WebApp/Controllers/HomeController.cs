using System.Web.Mvc;

namespace WebApp.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to Nerds at NNUG!";
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}

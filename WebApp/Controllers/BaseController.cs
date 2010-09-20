using System.Security.Principal;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public abstract class BaseController : Controller
    {
        public IPrincipal MockUser { get; set; }
        
        /// <summary>
        /// Allows us to inject a mock User object for testing.
        /// See http://www.hanselman.com/blog/IPrincipalUserModelBinderInASPNETMVCForEasierTesting.aspx for better, but more complex ways of solving it
        /// </summary>
        public IPrincipal CurrentUser
        {
            get { return MockUser ?? User; }
        }
    }
}

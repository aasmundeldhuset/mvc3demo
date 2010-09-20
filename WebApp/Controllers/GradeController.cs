using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web.Mvc;
using BusinessLogic;
using Domain;
using Domain.Repository;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class GradeController : Controller
    {
        private readonly IRepository _repo;
        private readonly GradeLogic _logic;
        private readonly IPrincipal _mockUser;
        
        public GradeController(IRepository repo, GradeLogic logic, IPrincipal mockUser = null)
        {
            _repo = repo;
            _logic = logic;
            _mockUser = mockUser;
        }
        
        [HttpPost]
        public ActionResult GradeArticle(int id, int gradeValue)
        {
            _logic.GradeArticle(id, CurrentUser.Identity.Name, gradeValue);
            return RedirectToAction("Show", "Article", new {id});
        }

        /// <summary>
        /// Allows us to inject a mock User object for testing.
        /// See http://www.hanselman.com/blog/IPrincipalUserModelBinderInASPNETMVCForEasierTesting.aspx for better, but more complex ways of solving it
        /// </summary>
        private IPrincipal CurrentUser
        {
            get { return _mockUser ?? User; }
        }
    }
}

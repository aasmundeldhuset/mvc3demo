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
    public class GradeController : BaseController
    {
        private readonly GradeLogic _logic;
        
        public GradeController(GradeLogic logic)
        {
            _logic = logic;
        }
        
        [HttpPost]
        public ActionResult GradeArticle(int id, int gradeValue)
        {
            _logic.GradeArticle(id, CurrentUser.Identity.Name, gradeValue);
            return RedirectToAction("Show", "Article", new {id});
        }
    }
}

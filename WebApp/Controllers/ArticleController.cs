using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Domain;
using Domain.Repository;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IRepository _repo;

        public ArticleController(IRepository repo)
        {
            _repo = repo;
        }

        public ActionResult Index()
        {
            var articles = from article in _repo.GetAll<Article>().ToList()
                           orderby article.Title
                           select new ArticleListModel(article);
            return View(articles);
        }

        public ActionResult Show(int id)
        {
            var article = _repo.Get<Article>(id);
            return View(new ArticleDetailsModel(article));
        }

        public ActionResult Create()
        {
            var currentUser = _repo.GetWhere<User>(u => u.UserName == User.Identity.Name).Single();
            var article = new Article {Author = currentUser, Title = "New article", Summary = "", Body = ""};
            _repo.AddAllAndSave(article);
            return RedirectToAction("Edit", new {id = article.Id});
        }

        public ActionResult Edit(int id)
        {
            return View(_repo.Get<Article>(id));
        }

        [HttpPost]
        public ActionResult Edit(Article article)
        {
            try
            {
                var dbArticle = _repo.Get<Article>(article.Id);
                dbArticle.Title = article.Title;
                dbArticle.Summary = article.Summary;
                dbArticle.Body = article.Body;
                _repo.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(article);
            }
        }
    }
}

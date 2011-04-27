using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BusinessLogic;
using Domain;
using Domain.Repository;
using WebApp.Attributes;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class ArticleController : BaseController
    {
        private readonly IRepository _repo;
        private readonly AttachmentLogic _attachmentLogic;

        public ArticleController(IRepository repo, AttachmentLogic attachmentLogic)
        {
            _repo = repo;
            _attachmentLogic = attachmentLogic;
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
            ViewBag.Id = id;
            var article = _repo.Get<Article>(id);
            return View(new ArticleDetailsModel(article, CurrentUser.Identity.Name));
        }

        [Authorize(Roles = "User")]
        public ActionResult Create()
        {
            var currentUser = _repo.GetWhere<User>(u => u.UserName == User.Identity.Name).Single();
            var article = new Article {Author = currentUser, Title = "New article", Summary = "", Body = ""};
            _repo.AddAllAndSave(article);
            return RedirectToAction("Edit", new {id = article.Id});
        }

        [Authorize(Roles = "User")]
        public ActionResult Edit(int id)
        {
            ViewBag.Id = id;
            return View(_repo.Get<Article>(id));
        }

        [ActionName("Rediger")]
        public ActionResult MinMetodeMedCustomNavn(int id)
        {
            return RedirectToAction("Edit", new {id});
        }

        [HttpPost]
        [Stopwatch]
        [Authorize(Roles = "User")]
        public ActionResult Edit(Article article)
        {
            if (!ModelState.IsValid) return View(article);
            try
            {
                var dbArticle = _repo.Get<Article>(article.Id);
                dbArticle.Title = article.Title;
                dbArticle.Summary = article.Summary;
                dbArticle.Body = article.Body;
                _repo.SaveChanges();

                if (Request.Files != null && Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
                {
                    _attachmentLogic.SaveAttachment(article.Id, Request.Files[0]);
                }
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View(article);
            }
        }

        public FileStreamResult DownloadAttachment(int id)
        {
            return new FileStreamResult(_attachmentLogic.LoadAttachment(id), "application/pdf");
        }
    }
}

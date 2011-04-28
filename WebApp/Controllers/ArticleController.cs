using System;
using System.Linq;
using System.Text;
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
            var articles = from article in _repo.GetAll<Article>().Where(u => u.PublishDate <= DateTime.Today).ToList()
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
            var article = new Article {Title = "New article", Summary = "", Body = "", EmailAddress = "", PublishDate = DateTime.Today};
            return View("Edit", article);
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
                Article dbArticle;
                if (article.Id == 0)
                {
                    var currentUser = _repo.GetWhere<User>(u => u.UserName == User.Identity.Name).Single();
                    dbArticle = new Article {Author = currentUser};
                    _repo.Add(dbArticle);
                }
                else
                {
                    dbArticle = _repo.Get<Article>(article.Id);
                }
                dbArticle.Title = article.Title;
                dbArticle.Summary = article.Summary;
                dbArticle.Body = article.Body;
                dbArticle.PublishDate = article.PublishDate;
                dbArticle.EmailAddress = article.EmailAddress;
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

        public JsonResult ShowAsJson(int id)
        {
            var article = _repo.Get<Article>(id);
            return new JsonResult
                   {
                       Data = new ArticleDetailsModel(article, CurrentUser.Identity.Name),
                       ContentType = "text/json",
                       ContentEncoding = Encoding.UTF8,
                       JsonRequestBehavior = JsonRequestBehavior.AllowGet
                   };
        }
    }
}

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
        public ActionResult Index()
        {
            using (var repo = new Repository())
            {
                var articles = from article in repo.GetAll<Article>().ToList()
                               orderby article.Title
                               select new ArticleViewModel(article);
                return View(articles);
            }
        }

        public ActionResult Show(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Article article)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

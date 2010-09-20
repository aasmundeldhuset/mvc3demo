using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Utilities;
using Domain;

namespace WebApp.ViewModels
{
    public class ArticleDetailsModel
    {
        public string Title { get; set; }
        public string AuthorUserName { get; set; }
        public string Summary { get; set; }
        public IHtmlString Body { get; set; }
        
        public ArticleDetailsModel(Article article)
        {
            Title = article.Title;
            AuthorUserName = article.Author.UserName;
            Summary = article.Summary;
            Body = MiniLanguageFormatter.Format(article.Body);
        }
    }
}
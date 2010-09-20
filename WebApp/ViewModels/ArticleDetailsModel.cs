using System.Linq;
using System.Web;
using System.Web.Mvc;
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

            string encoded = HttpUtility.HtmlEncode(article.Body);
            var paragraphs = encoded.Split('\n').Select(p => "<p>" + p + "</p>");
            string encodedWithParagraphs = string.Concat(paragraphs);
            Body = new HtmlString(
                encodedWithParagraphs
                .Replace("[b]", "<strong>")
                .Replace("[/b]", "</strong>"));
        }
    }
}
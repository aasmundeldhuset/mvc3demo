using System.Linq;
using System.Web;
using BusinessLogic.Utilities;
using Commons;
using Domain;

namespace WebApp.ViewModels
{
    public class ArticleDetailsModel
    {
        public string Title { get; set; }
        public string AuthorUserName { get; set; }
        public string GradeAverage { get; set; }
        public string Summary { get; set; }
        public IHtmlString Body { get; set; }
        public int? GradeValue { get; set; }
        
        public ArticleDetailsModel(Article article, string currentUserName)
        {
            Title = article.Title;
            AuthorUserName = article.Author.UserName;
            GradeAverage = Format.Grade(article.GetGradeAverage());
            Summary = article.Summary;
            Body = MiniLanguageFormatter.Format(article.Body);
            var userGrade = article.Grades.SingleOrDefault(g => g.User.UserName == currentUserName);
            GradeValue = (userGrade == null ? null : (int?)userGrade.GradeValue);
        }
    }
}

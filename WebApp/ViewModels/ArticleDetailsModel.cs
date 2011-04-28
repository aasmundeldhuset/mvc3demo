using System.ComponentModel.DataAnnotations;
using System.Linq;
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
        public string Body { get; set; }

        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        public int? GradeValue { get; set; }
        
        public ArticleDetailsModel(Article article, string currentUserName)
        {
            Title = article.Title;
            AuthorUserName = article.Author.UserName;
            GradeAverage = Format.Grade(article.GetGradeAverage());
            Summary = article.Summary;
            Body = article.Body;
            EmailAddress = article.EmailAddress;
            var userGrade = article.Grades.SingleOrDefault(g => g.User.UserName == currentUserName);
            GradeValue = (userGrade == null ? null : (int?)userGrade.GradeValue);
        }
    }
}

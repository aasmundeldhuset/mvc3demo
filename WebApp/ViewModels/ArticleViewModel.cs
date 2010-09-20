using Domain;

namespace WebApp.ViewModels
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorUserName { get; set; }
        public string Summary { get; set; }
        
        public ArticleViewModel(Article article)
        {
            Id = article.Id;
            Title = article.Title;
            AuthorUserName = article.Author.UserName;
            Summary = article.Summary;
        }
    }
}
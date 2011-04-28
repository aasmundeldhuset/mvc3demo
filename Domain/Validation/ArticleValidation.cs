using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Validation
{
    public class ArticleValidation
    {
        [WordCount(5)]
        public string Title { get; set; }

        [DisplayName("Publish date")]
        public DateTime PublishDate { get; set; }

        [DisplayName("Email address")]
        public string EmailAddress { get; set; }

        [Required, StringLength(100, MinimumLength = 10)]
        public string Summary { get; set; }
    }
}

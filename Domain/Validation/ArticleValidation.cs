using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Validation
{
    public class ArticleValidation
    {
        [DisplayName("Tittel")]
        [WordCount(5)]
        public string Title { get; set; }


        [DisplayName("Test")]
        [Required, StringLength(100, MinimumLength = 10)]
        public string Summary { get; set; }

        //[UIHint("EmailAddress")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
    }
}

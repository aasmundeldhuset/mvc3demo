using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

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
    }
}

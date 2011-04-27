using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Domain.Validation
{

    public class WordCountAttribute : ValidationAttribute, IClientValidatable
    {
        private int _maxWordCount;

        public WordCountAttribute(int maxWordCount)
        {
            _maxWordCount = maxWordCount;
            ErrorMessage = "Max amount of words in {0} is {1}";
        }

        string FormatErrorMessage(string thisPropertyDisplayName)
        {
            return String.Format(ErrorMessageString, thisPropertyDisplayName, _maxWordCount);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
                ValidationType = "wordcount",
            };

            rule.ValidationParameters["max"] = _maxWordCount;

            yield return rule;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var thisValue = (string) value;

            return thisValue.Split(' ').Length < _maxWordCount ? 
                null : 
                new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
    }
}

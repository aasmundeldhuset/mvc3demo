using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BusinessLogic.Utilities
{
    public static class MiniLanguageFormatter
    {
        private static readonly IDictionary<string, string> TagReplacements = 
            new Dictionary<string, string>
            {
                {"b", "strong"},
                {"i", "em"},
                {"sup", "sup"},
                {"sub", "sub"},
            };

        public static IHtmlString Format(string input)
        {
            string encoded = HttpUtility.HtmlEncode(input);
            string[] encodedParagraphs = encoded.Split('\n');
            var encodedWithPTags = string.Concat(encodedParagraphs.Select(p => "<p>" + p + "</p>"));
            var encodedWithTagReplacements = new StringBuilder(encodedWithPTags);
            foreach (var replacement in TagReplacements)
            {
                string miniLanguageStartTag = "[" + replacement.Key + "]";
                string htmlStartTag = "<" + replacement.Value + ">";
                encodedWithTagReplacements.Replace(miniLanguageStartTag, htmlStartTag);
                string miniLanguageEndTag = "[/" + replacement.Key + "]";
                string htmlEndTag = "</" + replacement.Value + ">";
                encodedWithTagReplacements.Replace(miniLanguageEndTag, htmlEndTag);
            }
            return new HtmlString(encodedWithTagReplacements.ToString());
        }
    }
}

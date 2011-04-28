using System.Web;
using System.Web.Mvc;
using BusinessLogic.Utilities;

namespace WebApp.Helpers
{
    public static class RichTextHelper
    {
        public static IHtmlString Rich(this HtmlHelper helper, string bodyText)
        {
            return MiniLanguageFormatter.Format(bodyText);
        }
    }
}
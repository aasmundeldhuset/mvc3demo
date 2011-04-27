using System.Diagnostics;
using System.Web.Mvc;

namespace WebApp.Attributes
{
    public class StopwatchAttribute : ActionFilterAttribute
    {
        private readonly Stopwatch _stopwatch;

        public StopwatchAttribute()
        {
            _stopwatch = new Stopwatch();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _stopwatch.Start();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            _stopwatch.Stop();

            var httpContext = filterContext.HttpContext;
            var response = httpContext.Response;
            var elapsed = _stopwatch.Elapsed.ToString();
            // Works for IIS
            response.AddHeader("X-Stopwatch", elapsed);
        }
    }
}
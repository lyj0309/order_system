using log4net;
using System.Diagnostics;

namespace Web.Api.Middleware
{
    public class LogMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILog logger = LogManager.GetLogger(typeof(LogMiddleware));
        public LogMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();
            await next(context);
            logger.Info($" Auditor api log : {context.Request.Method} , {context.Request.Path} , duration : {stopwatch.ElapsedMilliseconds} ");
        }
    }
}

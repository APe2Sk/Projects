using Serilog;
using System.Diagnostics;

namespace LotoApplication.Api.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate next;

        public LoggingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                var stopwatch = new Stopwatch();
                Log.Logger.Information("Request - ", context.Request.Headers);

                stopwatch.Start();
                await next(context);
                stopwatch.Stop();
                if (stopwatch.ElapsedMilliseconds > 500)
                {
                    Log.Logger.Warning("Request took {duration}", stopwatch.ElapsedMilliseconds);
                }
                Log.Logger.Information("Response", context.Response.Headers);
            }
            catch (Exception ex)
            {
                Log.Logger.Error("An exception occured", ex);
                throw;
            }
        }
    }
}

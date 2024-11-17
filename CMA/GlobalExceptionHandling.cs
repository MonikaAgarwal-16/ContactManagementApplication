
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;
using System.Text.Json;

namespace ESS.API.Middlewares
{

    public class GlobalExceptionHandling
    {
        private readonly RequestDelegate _next;
        public GlobalExceptionHandling(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IConfiguration config)
        {
            var requestBodyData = string.Empty;
            try
            {
                await _next(httpContext);

            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex, requestBodyData, config);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception, string bodyData, IConfiguration config)
        {

            var exceptionResult = JsonSerializer.Serialize(
                new
                {

                    AppErrorMsg = "Someting went wrong, please try again.",
                    Message = exception.Message,

                    StackTrace = exception.StackTrace
                });
            context.Response.ContentType = "application/json";

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsync(exceptionResult);
        }


    }
}

using FluentValidation;
using Framework.Application;
using Framework.Domain.Enum;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NLog;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Extensions
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private static ILogger _logger = LogManager.GetCurrentClassLogger();
        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.BadRequest;
            var result = string.Empty;
            switch (exception)
            {
                case ValidationException validationException:
                    result = JsonConvert.SerializeObject(validationException.Errors.Select(x => x.ErrorMessage));
                    break;
                case Framework.Application.Common.Exceptions.ValidationException validationException:
                    result = JsonConvert.SerializeObject(validationException.Failures);
                    break;
                case ExceptionResult e:
                    result = JsonConvert.SerializeObject(e.Message);
                    break;
                default:
                    code = HttpStatusCode.InternalServerError;break;
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            if (string.IsNullOrEmpty(result))
            {
                result = JsonConvert.SerializeObject("internal Error");
            }
            return context.Response.WriteAsync(JsonConvert.SerializeObject(new { error = result}));
        }
    }
    public static class CustomExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}

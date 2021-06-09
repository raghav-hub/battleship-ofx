using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BattleshipChallenge.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace BattleshipChallenge.Api.Infrastructure
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            HttpStatusCode code;
            var message = "error processing request, please contact the admin";

            switch (exception)
            {
                case NotFoundException _:
                    code = HttpStatusCode.NotFound;
                    message = exception.Message;
                    break;

                case NotImplementedException _:
                    code = HttpStatusCode.MethodNotAllowed;
                    message = exception.Message;
                    break;

                default:
                    code = HttpStatusCode.InternalServerError;
                    message = "error processing request, please contact the admin";
                    _logger.LogError(exception, "Unexpected exception thrown, {exceptionMessage}", exception.Message);
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = (int)code,
                Message = message
            }.ToString());
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;
using TASKMANAGER.DB.Exceptions;

namespace TASKMANAGER.API.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _request;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate request, ILogger<GlobalExceptionMiddleware> logger)
        {
            _request = request;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _request(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                await HandleException(context, ex);
            }
        }

        private Task HandleException(HttpContext context, Exception exception)
        {
            var errorCode = nameof(HttpStatusCode.InternalServerError);
            var statusCode = HttpStatusCode.InternalServerError;
            var message = exception.Message;

            if (exception is UnauthorizedAccessException)
            {
                throw new TaskManagerException(ErrorCode.Unauthorized);
            }

            if(exception is TaskManagerException taskManagerException)
            {
                statusCode = taskManagerException.ErrorCode.StatusCode;
                errorCode = taskManagerException.ErrorCode.Message;
                message = string.IsNullOrEmpty(taskManagerException.Message) ? errorCode : taskManagerException.Message;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            var responseBody = JsonConvert.SerializeObject(new { errorCode, message });

            return context.Response.WriteAsync(responseBody);
        }
    }
}

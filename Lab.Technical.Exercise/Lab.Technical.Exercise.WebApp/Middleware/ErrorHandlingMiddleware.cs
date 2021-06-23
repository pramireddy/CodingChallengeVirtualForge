using Lab.Technical.Exercise.DataContracts;
using Lab.Technical.Exercise.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Lab.Technical.Exercise.WebApp.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);

                if (context.Response.StatusCode == StatusCodes.Status404NotFound && !context.Response.HasStarted)
                {
                    throw new NotFoundException("The requested resource was not found");
                }
            }
            catch (NotFoundException ex)
            {
                await HandleExceptionAsync(context, ex, HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, HttpStatusCode.InternalServerError);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception, HttpStatusCode statusCode)
        {
            context.Response.StatusCode = (int)statusCode;

            // TO DO: Log exceptions : Azure AppInsights or File

            var message = "The requested resource was not found";

            if (statusCode == HttpStatusCode.NotFound && !string.IsNullOrEmpty(exception.Message))
            {
                message = exception.Message;
            }

            var response = new Error
            {
                ErrorDescription = $"{(int)statusCode} - {message}",
                ErrorCode = message
            };

            string responseStringContent;

            context.Response.ContentType = Application.Json;
            responseStringContent =
                JsonSerializer.Serialize(response, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            return context.Response.WriteAsync(responseStringContent);
        }
    }
}

using DealershipRun.AppHost.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace DealershipRun.AppHost.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context) {
            try
            {
                await _next(context);
            }
            catch (NotFoundException ex) {
                await HandleExceptionAsync(context, HttpStatusCode.NotFound, ex.Message);
            }
            catch (BadRequestException ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError,"An unexpected error has occurred");
            }
        }


    
     private static async Task HandleExceptionAsync(HttpContext context, HttpStatusCode statusCode, string message)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var response = new { status = (int)statusCode, message };
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
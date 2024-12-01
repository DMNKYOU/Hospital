using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PMI.Hospital.Shared.Exceptions;
using System;

namespace PMI.Hospital.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            if (exception is EntityNotFoundException)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                var response = new { message = exception.Message };

                return context.Response.WriteAsJsonAsync(response);
            }

            if (exception is InvalidOperationException)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                var response = new { message = exception.Message };

                return context.Response.WriteAsJsonAsync(response);
            }

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            return context.Response.WriteAsJsonAsync(new { message = exception.Message });
        }
    }
}

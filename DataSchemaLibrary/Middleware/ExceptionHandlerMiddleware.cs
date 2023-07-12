//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Diagnostics;
//using Microsoft.AspNetCore.Http;
//using Newtonsoft.Json;
//using System;


//namespace DataSchemaLibrary.Middleware
//{
//    public class ExceptionHandlerMiddleware
//    {
//        private readonly RequestDelegate _next;

//        public ExceptionHandlerMiddleware(RequestDelegate next)
//        {
//            _next = next;
//        }

//        public async Task Invoke(HttpContext context)
//        {
//            try
//            {
//                await _next(context);
//            }
//            catch (Exception ex)
//            {
//                await HandleExceptionAsync(context, ex);
//            }
//        }

//        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
//        {
//            var statusCode = StatusCodes.Status500InternalServerError;
//            var errorMessage = "An unexpected error occurred.";

//            // Handle specific exception types and set appropriate status code and error message
//            // You can customize this logic based on your requirements

//            var response = new { error = errorMessage };
//            var jsonResponse = JsonConvert.SerializeObject(response);
//            context.Response.ContentType = "application/json";
//            context.Response.StatusCode = statusCode;
//            return context.Response.WriteAsync(jsonResponse);
//        }
//    }
//}

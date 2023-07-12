//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.Logging;
//using System.IO;
//using System.IO.Pipelines;
//using System.Text;
//using System.Threading.Tasks;

//namespace DataSchemaLibrary.Middleware
//{   
//    public class LoggingMiddleware
//    {
//        private readonly RequestDelegate _next;
//        private readonly ILogger<LoggingMiddleware> _logger;

        
//        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
//        {
//            _next = next;
//            _logger = logger;
//        }

//        public async Task Invoke(HttpContext context)
//        {
//            var requestBodyStream = new MemoryStream();
//            var originalRequestBody = context.Request.Body;

//            await context.Request.Body.CopyToAsync(requestBodyStream);
//            requestBodyStream.Seek(0, SeekOrigin.Begin);
//            var requestBodyText = await new StreamReader(requestBodyStream, Encoding.UTF8).ReadToEndAsync();
//            requestBodyStream.Seek(0, SeekOrigin.Begin);
//            context.Request.Body = requestBodyStream;


//            _logger.LogInformation($"Request: {context.Request.Method} {context.Request.Path} {context.Request.QueryString}");
//            _logger.LogInformation($"Headers: {context.Request.Headers}");
//            _logger.LogInformation($"Query Params: {context.Request.Query}");
//            _logger.LogInformation($"Body: {requestBodyText}");

//            await _next(context);

//            context.Request.Body = originalRequestBody;
//        }
//    }
//}

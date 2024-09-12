using Abi.RestService.Domain.Results;
using System.Net;

namespace Abi.RestService.API.Middlewares
{
	public class ExceptionHandlerMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly Serilog.ILogger _logger;

		public ExceptionHandlerMiddleware(RequestDelegate next, Serilog.ILogger logger)
		{
			_next = next;
			_logger = logger;
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

		private async Task HandleExceptionAsync(HttpContext context, Exception ex)
		{
			_logger.Error(ex, ex.Message);

			var responce = ex switch
			{
				_ => new BaseResult()
				{
					ErrorMessage = "Internal server error",
				}
			};

			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

			await context.Response.WriteAsJsonAsync(responce);
		}
	}
}

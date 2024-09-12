using Abi.RestService.Domain.Options;
using Abi.RestService.DAL.DI;
using Abi.RestService.Application.DI;
using Abi.RestService.API.Middlewares;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;


builder.Services.Configure<XlsFileOptions>(configuration.GetSection(XlsFileOptions.DefaultSection));

builder.Services.AddControllers();

builder.Services.AddFileContext();
builder.Services.AddApplication();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Host.UseSerilog((context, configuration) =>
{
	configuration.ReadFrom.Configuration(context.Configuration);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.Run();

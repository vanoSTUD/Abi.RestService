using Abi.RestService.Application.Services;
using Abi.RestService.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Abi.RestService.Application.DI;

public static class DependencyInjection
{
	public static void AddApplication(this IServiceCollection services)
	{
		services.AddScoped<ITenderService, TenderService>();
	}
}

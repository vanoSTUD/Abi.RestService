using Abi.RestService.DAL.Repositories;
using Abi.RestService.Domain.Interfaces;
using Abi.RestService.Domain.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Abi.RestService.DAL.DI;

public static class DependencyInjection
{
	public static void AddFileContext(this IServiceCollection services)
	{
		services.AddScoped<IFileContext, XlsFileContext>(serviceProvider => new XlsFileContext(
			options: serviceProvider.GetRequiredService<IOptions<XlsFileOptions>>()
		));

		AddRepositories(services);
	} 

	private static void AddRepositories(IServiceCollection services)
	{
		services.AddScoped<ITenderRepository, TenderRepository>();
	}
}

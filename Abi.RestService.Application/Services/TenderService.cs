using Abi.RestService.Domain.Interfaces;
using Abi.RestService.Domain.Models;
using Abi.RestService.Domain.Results;
using Serilog;

namespace Abi.RestService.Application.Services;

public class TenderService : ITenderService
{
	private readonly ITenderRepository _tenderRepository;
	private readonly ILogger _logger;

	public TenderService(ITenderRepository tenderRepository, ILogger logger)
	{
		_tenderRepository = tenderRepository;
		_logger = logger;
	}

	public async Task<CollectionResult<Tender>> GetAllAsync()
	{
		var tenders = await _tenderRepository.GetAllAsync();

		if (tenders == null)
		{
			_logger.Warning("Tenders is null");

			return new CollectionResult<Tender>
			{
				ErrorMessage = "Tenders is null"
			};
		}

		return new CollectionResult<Tender>
		{
			Data = tenders,
			Count = tenders.Count()
		};
	}
}

using Abi.RestService.Domain.Interfaces;
using Abi.RestService.Domain.Models;
using Abi.RestService.Domain.Results;

namespace Abi.RestService.Application.Services;

public class TenderService : ITenderService
{
	private readonly ITenderRepository _tenderRepository;

	public TenderService(ITenderRepository tenderRepository)
	{
		_tenderRepository = tenderRepository;
	}

	public async Task<CollectionResult<Tender>> GetAllAsync()
	{
		var tenders = await _tenderRepository.GetAllAsync();

		if (tenders == null)
		{
			return new CollectionResult<Tender>
			{
				ErrorMessage = "Tenders is empty"
			};
		}

		return new CollectionResult<Tender>
		{
			Data = tenders,
			Count = tenders.Count()
		};
	}
}

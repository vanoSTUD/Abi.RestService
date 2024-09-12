using Abi.RestService.Domain.Models;
using Abi.RestService.Domain.Results;

namespace Abi.RestService.Domain.Interfaces;

public interface ITenderService
{
	public Task<CollectionResult<Tender>> GetAllAsync();
}

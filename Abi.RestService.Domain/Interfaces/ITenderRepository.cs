using Abi.RestService.Domain.Models;

namespace Abi.RestService.Domain.Interfaces;

public interface ITenderRepository
{
	public Task<IEnumerable<Tender>> GetAllAsync();
}

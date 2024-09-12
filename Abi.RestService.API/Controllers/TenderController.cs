using Abi.RestService.Domain.Interfaces;
using Abi.RestService.Domain.Models;
using Abi.RestService.Domain.Results;
using Microsoft.AspNetCore.Mvc;

namespace Abi.RestService.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TenderController : ControllerBase
	{
		private readonly ITenderService _tenderService;

		public TenderController(ITenderService tenderService)
		{
			_tenderService = tenderService;
		}

		[HttpGet("get-all")]
		public async Task<ActionResult<CollectionResult<Tender>>> GetAll()
		{
			var responce = await _tenderService.GetAllAsync();

			if (responce.Success)
			{
				return Ok(responce);
			}

			return BadRequest(responce);
		}
	}
}

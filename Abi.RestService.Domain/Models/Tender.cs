namespace Abi.RestService.Domain.Models;

public class Tender
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public DateTime StartDate { get; set; }
	public DateTime EndDate { get; set; }
	public string Url {  get; set; } = string.Empty;
}

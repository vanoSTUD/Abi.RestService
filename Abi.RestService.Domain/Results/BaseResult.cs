namespace Abi.RestService.Domain.Results;

public class BaseResult
{
	public bool Success => ErrorMessage == null;
	public string? ErrorMessage { get; set; } = null;
}

public class BaseResult<T> : BaseResult where T : class
{
	public T? Data { get; set; }
}

public class CollectionResult<T> : BaseResult<IEnumerable<T>>
{
	public int Count { get; set; }
}
using Abi.RestService.Domain.Interfaces;
using Abi.RestService.Domain.Options;
using Aspose.Cells;
using Microsoft.Extensions.Options;

namespace Abi.RestService.DAL;

public class XlsContext : IFileContext
{
	public XlsContext(IOptions<XlsFileOptions> options)
    {
		string dataFileName = options.Value.FileName;
		string currentDirectory = Directory.GetCurrentDirectory();
		string pathDataFile = $"{currentDirectory}/{dataFileName}";

		Workbook = new Workbook(pathDataFile);
	}

	public Workbook Workbook { get; private set; }
}

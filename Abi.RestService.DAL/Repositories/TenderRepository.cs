using Abi.RestService.Domain;
using Abi.RestService.Domain.Interfaces;
using Abi.RestService.Domain.Models;
using Aspose.Cells;
using System.Reflection;

namespace Abi.RestService.DAL.Repositories;

public class TenderRepository : ITenderRepository
{
	private readonly IFileContext _fileContext;

	public TenderRepository(IFileContext fileContext)
	{
		_fileContext = fileContext;
	}

	public async Task<IEnumerable<Tender>> GetAllAsync()
	{
		int sheetNumber = 0;

		Workbook wb = _fileContext.Workbook;
		Worksheet worksheet = wb.Worksheets[sheetNumber];

		int rows = worksheet.Cells.MaxDataRow;
		int cols = worksheet.Cells.MaxDataColumn;
		List<Tender> tenders = [];

		for (int i = 1; i <= rows; i++)
		{
			Tender newTender = new();
			
			for (int j = 0; j <= cols; j++)
			{
				object value = worksheet.Cells[i, j].Value;
				SetProperty(newTender, j, value);
			}

			tenders.Add(newTender);
		}

		return await Task.FromResult(tenders);
    }

	private void SetProperty(Tender tender, int index, object valueObj)
	{
		ArgumentNullException.ThrowIfNull(tender);
		ArgumentNullException.ThrowIfNull(valueObj);

		string tenderPropertyName = ((TenderProperties)index).ToString();
		PropertyInfo? tenderProperty = typeof(Tender).GetProperty(tenderPropertyName);

		if (tenderProperty == null)
			throw new InvalidOperationException($"{typeof(Tender)} or {typeof(TenderProperties)} doesn't contain property with index {index}");

		Type propertyType = tenderProperty.PropertyType;

		object value = Convert.ChangeType(valueObj, propertyType);
		tenderProperty.SetValue(tender, value, null);
	}
}

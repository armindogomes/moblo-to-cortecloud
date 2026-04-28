using CsvHelper;
using CsvHelper.Configuration;
using MobloToCorteCloud.Models;
using System.Globalization;

namespace MobloToCorteCloud.Services;

internal class CsvReaderService {
	public List<CsvRecord> ReadCsvFile(string filePath) {
		var config = new CsvConfiguration(CultureInfo.InvariantCulture) {
			HasHeaderRecord = true,
			Delimiter = ",",
		};

		using var reader = new StreamReader(filePath);
		using var csv = new CsvReader(reader, config);
		
		var records = csv.GetRecords<CsvRecord>().ToList();
		return records;
	}
}

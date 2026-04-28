using MobloToCorteCloud.Models;
using static System.String;

namespace MobloToCorteCloud.Services;

internal class ConverterService {

	const string OK = "ok";
	public static List<ExcelRecord> ConvertCsvToExcel(List<CsvRecord> csvRecords, string complemento) {
		var excelRecords = new List<ExcelRecord>();

		foreach (var csv in csvRecords) {
			var (c1, c2, l1, l2) = GetFitaValues(csv.Part);

			var excel = new ExcelRecord {
				Quantidade = csv.Quantity,
				Comprimento = csv.Length,
				Largura = csv.Width,
				Funcao = csv.Part,
				FitaC1 = c1,
				FitaC2 = c2,
				FitaL1 = l1,
				FitaL2 = l2,
				Complemento = string.IsNullOrWhiteSpace(csv.Group) ? complemento : csv.Group,
				Material = string.Empty,
				Girar = string.Empty
			};

			excelRecords.Add(excel);
		}

		return excelRecords;
	}

	private static (string c1, string c2, string l1, string l2) GetFitaValues(string part) {
		var partLower = part.ToLowerInvariant();

		return partLower switch {
			_ when partLower.StartsWith("pta ") => (OK, OK, OK, Empty),
			_ when partLower.StartsWith("prt ") => (OK, Empty, Empty, Empty),
			_ when partLower.StartsWith("bdj ") => (OK, Empty, OK, OK),
			_ when partLower.StartsWith("ltr ") => (OK, Empty, OK, Empty),
			_ when partLower.StartsWith("tpo ") => (OK, Empty, OK, OK),
			_ when partLower.StartsWith("bse ") => (OK, Empty, OK, OK),
			_ when partLower.StartsWith("fnd ") => (Empty, Empty, Empty, Empty),
			_ when partLower.StartsWith("div ") => (OK, Empty, Empty, Empty),
			_ when partLower.StartsWith("srf") => (Empty, Empty, Empty, Empty),
			_ => (OK, OK, OK, OK)
		};
	}
}
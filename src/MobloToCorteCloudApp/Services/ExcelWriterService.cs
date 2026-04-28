using ClosedXML.Excel;
using MobloToCorteCloudApp.Models;

namespace MobloToCorteCloudApp.Services;

internal class ExcelWriterService {
	public void WriteExcelFile(List<ExcelRecord> records, string outputPath) {
		using var workbook = new XLWorkbook();
		var worksheet = workbook.Worksheets.Add("Dados");

		worksheet.Cell(1, 1).Value = "Quantidade";
		worksheet.Cell(1, 2).Value = "Comprimento";
		worksheet.Cell(1, 3).Value = "Largura";
		worksheet.Cell(1, 4).Value = "Função";
		worksheet.Cell(1, 5).Value = "Fita C1";
		worksheet.Cell(1, 6).Value = "Fita C2";
		worksheet.Cell(1, 7).Value = "Fita L1";
		worksheet.Cell(1, 8).Value = "Fita L2";
		worksheet.Cell(1, 9).Value = "Material";
		worksheet.Cell(1, 10).Value = "Complemento";
		worksheet.Cell(1, 11).Value = "Girar";

		for (int i = 0; i < records.Count; i++) {
			var record = records[i];
			int row = i + 2;

			worksheet.Cell(row, 1).Value = record.Quantidade;
			worksheet.Cell(row, 2).Value = record.Comprimento;
			worksheet.Cell(row, 3).Value = record.Largura;
			worksheet.Cell(row, 4).Value = record.Funcao;
			worksheet.Cell(row, 5).Value = record.FitaC1;
			worksheet.Cell(row, 6).Value = record.FitaC2;
			worksheet.Cell(row, 7).Value = record.FitaL1;
			worksheet.Cell(row, 8).Value = record.FitaL2;
			worksheet.Cell(row, 9).Value = record.Material;
			worksheet.Cell(row, 10).Value = record.Complemento;
			worksheet.Cell(row, 11).Value = record.Girar;
		}

		worksheet.Columns().AdjustToContents();
		workbook.SaveAs(outputPath);
	}
}

using CsvHelper.Configuration.Attributes;

namespace MobloToCorteCloudApp.Models;

internal class CsvRecord {
	public string Group { get; set; } = string.Empty;
	public string Part { get; set; } = string.Empty;
	public int Quantity { get; set; }

	[Name("Length(mm)")]
	public decimal Length { get; set; }

	[Name("Width(mm)")]
	public decimal Width { get; set; }

	[Name("Thickness(mm)")]
	public decimal Thickness { get; set; }

	public string Material { get; set; } = string.Empty;
}

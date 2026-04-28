namespace MobloToCorteCloudApp.Models;

internal class ExcelRecord {
	public int Quantidade { get; set; }
	public decimal Comprimento { get; set; }
	public decimal Largura { get; set; }
	public string Funcao { get; set; } = string.Empty;
	public string FitaC1 { get; set; } = "ok";
	public string FitaC2 { get; set; } = "ok";
	public string FitaL1 { get; set; } = "ok";
	public string FitaL2 { get; set; } = "ok";
	public string Material { get; set; } = string.Empty;
	public string Complemento { get; set; } = string.Empty;
	public string Girar { get; set; } = string.Empty;
}

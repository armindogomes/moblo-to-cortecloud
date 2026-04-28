using MobloToCorteCloudApp.Services;
using System.Reflection;

var version = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "1.0.0";
Console.WriteLine($"Versão: {version}");
Console.WriteLine("=== Conversor CSV Moblo para Excel Corte Cloud ===\n");

if (args.Length == 0) {
	Console.WriteLine("Erro: Nenhum arquivo CSV foi fornecido.");
	Console.WriteLine("Uso: MobloToCorteCloudApp.exe <caminho-do-arquivo-csv>");
	Console.WriteLine("\nPressione qualquer tecla para sair...");
	Console.ReadKey();
	return;
}

var csvPath = args[0];

if (!File.Exists(csvPath)) {
	Console.WriteLine($"Erro: Arquivo CSV não encontrado: {csvPath}");
	Console.WriteLine("\nPressione qualquer tecla para sair...");
	Console.ReadKey();
	return;
}

Console.Write("Digite o valor para o campo Complemento (cozinha, sala, plantas...): ");
var complemento = Console.ReadLine() ?? string.Empty;

var outputDirectory = Path.GetDirectoryName(csvPath) ?? Directory.GetCurrentDirectory();
Directory.CreateDirectory(outputDirectory);

var csvFileName = Path.GetFileNameWithoutExtension(csvPath);
var excelPath = Path.Combine(outputDirectory, $"{csvFileName}.xlsx");

try {
	var csvReader = new CsvReaderService();
	var converter = new ConverterService();
	var excelWriter = new ExcelWriterService();
	var clipboardService = new ClipboardService();

	Console.WriteLine("\nLendo arquivo CSV...");
	var csvRecords = csvReader.ReadCsvFile(csvPath);
	Console.WriteLine($"✓ {csvRecords.Count} registros lidos do CSV");

	Console.WriteLine("\nConvertendo dados...");
	var excelRecords = ConverterService.ConvertCsvToExcel(csvRecords, complemento);
	Console.WriteLine($"✓ {excelRecords.Count} registros convertidos");

	Console.WriteLine("\nGerando arquivo Excel...");
	excelWriter.WriteExcelFile(excelRecords, excelPath);
	Console.WriteLine($"✓ Arquivo Excel salvo em: {excelPath}");

	Console.WriteLine("\nCopiando dados para área de transferência...");
	clipboardService.CopyToClipboard(excelRecords);
	Console.WriteLine($"✓ {excelRecords.Count} linhas copiadas para a área de transferência");

	Console.WriteLine("\n=== Conversão concluída com sucesso! ===");
}
catch (Exception ex) {
	Console.WriteLine($"\n❌ Erro durante a conversão: {ex.Message}");
	Console.WriteLine(ex.StackTrace);
}

Console.WriteLine("\nPressione qualquer tecla para sair...");
Console.ReadKey();
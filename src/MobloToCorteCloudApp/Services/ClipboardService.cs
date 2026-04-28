using MobloToCorteCloudApp.Models;
using System.Globalization;
using System.Text;

namespace MobloToCorteCloudApp.Services;

internal class ClipboardService {
    public void CopyToClipboard(List<ExcelRecord> records) {
        var sb = new StringBuilder();
        var culture = CultureInfo.CurrentCulture;

        foreach (var record in records) {
            sb.AppendLine(string.Join("\t",
                record.Quantidade,
                record.Comprimento.ToString(culture),
                record.Largura.ToString(culture),
                record.Funcao,
                record.FitaC1,
                record.FitaC2,
                record.FitaL1,
                record.FitaL2,
                record.Material,
                record.Complemento,
                record.Girar
            ));
        }

        if (sb.Length > 0) {
            sb.Length -= Environment.NewLine.Length;
        }

        TextCopy.ClipboardService.SetText(sb.ToString());
    }
}

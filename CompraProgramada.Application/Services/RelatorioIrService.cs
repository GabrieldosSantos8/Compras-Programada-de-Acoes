using CompraProgramada.Domain.Services;

namespace CompraProgramada.Application.Services;

public class RelatorioIrService
{
    private readonly CalculoImpostoService _impostoService;

    public RelatorioIrService(CalculoImpostoService impostoService)
    {
        _impostoService = impostoService;
    }

    public object GerarRelatorio(
        decimal totalVendasMes,
        decimal lucroLiquidoMes)
    {
        var ir = _impostoService.CalcularIrSobreLucro(
            totalVendasMes,
            lucroLiquidoMes);

        return new
        {
            TotalVendasMes = totalVendasMes,
            LucroLiquidoMes = lucroLiquidoMes,
            IRDevido = ir
        };
    }
}
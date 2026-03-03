namespace CompraProgramada.Domain.Services;

public class CalculoImpostoService
{
    private const decimal AliquotaIr = 0.20m;
    private const decimal AliquotaIrDedoDuro = 0.00005m; // 0,005%

    public decimal CalcularIrDedoDuro(decimal valorVenda)
    {
        if (valorVenda <= 0)
            throw new ArgumentException("Valor de venda inválido");

        return valorVenda * AliquotaIrDedoDuro;
    }

    public decimal CalcularIrSobreLucro(decimal totalVendasMes, decimal lucroLiquidoMes)
    {
        if (totalVendasMes <= 20000m)
            return 0m;

        if (lucroLiquidoMes <= 0)
            return 0m;

        return lucroLiquidoMes * AliquotaIr;
    }
}
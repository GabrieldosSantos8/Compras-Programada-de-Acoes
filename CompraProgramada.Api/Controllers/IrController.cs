using Microsoft.AspNetCore.Mvc;
using CompraProgramada.Application.Services;
using CompraProgramada.Domain.Services;

namespace CompraProgramada.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IrController : ControllerBase
{
    [HttpGet("mensal")]
    public IActionResult RelatorioIr(
        decimal totalVendasMes,
        decimal lucroLiquidoMes)
    {
        var impostoService = new CalculoImpostoService();
        var relatorioService = new RelatorioIrService(impostoService);

        var relatorio = relatorioService.GerarRelatorio(
            totalVendasMes,
            lucroLiquidoMes);

        return Ok(relatorio);
    }
}
using Microsoft.AspNetCore.Mvc;
using CompraProgramada.Domain.Entities;

namespace CompraProgramada.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarteiraController : ControllerBase
{
    [HttpGet("pl")]
    public IActionResult CalcularPL(
        decimal precoMedio,
        int quantidade,
        decimal cotacaoAtual)
    {
        var pl = (cotacaoAtual - precoMedio) * quantidade;
        return Ok(new { PL = pl });
    }
}
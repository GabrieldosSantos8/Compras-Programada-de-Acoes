using Microsoft.AspNetCore.Mvc;
using CompraProgramada.Application.DTOs;
using CompraProgramada.Infrastructure.Data;
using CompraProgramada.Application;
using CompraProgramada.Domain.Entities;



namespace CompraProgramada.Api.Controllers;

[ApiController]
[Route("api/admin")]
public class AdminController : ControllerBase
{
    private readonly AppDbContext _context;

    public AdminController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("cesta")]
public async Task<IActionResult> CriarCesta([FromBody] CriarCestaDto dto)
{
    if (dto.Itens.Count != 5)
        return BadRequest("A cesta deve conter 5 ativos.");

    if (dto.Itens.Sum(i => i.Percentual) != 100)
        return BadRequest("A soma dos percentuais deve ser 100%.");

    var itens = dto.Itens
        .Select(i => new ItemCesta(i.Ticker, i.Percentual))
        .ToList();

    var cesta = new CestaTopFive(DateTime.Now, itens);

    _context.Cestas.Add(cesta);
    await _context.SaveChangesAsync();

    return Ok();
}
}
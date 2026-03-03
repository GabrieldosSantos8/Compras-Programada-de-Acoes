using Microsoft.AspNetCore.Mvc;
using CompraProgramada.Application.DTOs;
using CompraProgramada.Application.Interfaces;

namespace CompraProgramada.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly IClienteService _service;

    public ClientesController(IClienteService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Criar(CreateClienteDto dto)
    {
        var id = await _service.CriarClienteAsync(dto);
        return CreatedAtAction(nameof(Criar), new { id }, new { id });
    }
}
using Microsoft.AspNetCore.Mvc;
using CompraProgramada.Application.Interfaces;
using CompraProgramada.Infrastructure.Services;

namespace CompraProgramada.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProcessamentoController : ControllerBase
{
    private readonly IProcessamentoService _service;

    
    [HttpPost("rodar")]
    public async Task<IActionResult> Rodar(DateTime data)
    {
        await _service.ProcessarComprasAsync(data);
        return Ok("Processamento executado");
    }

    [HttpPost("processar-consolidado")]
    public async Task<IActionResult> ProcessarConsolidado(DateTime data)
    {
    await _service.ProcessarComprasConsolidadasAsync(data);
    return Ok("Processamento consolidado executado");
    }
    
    [HttpGet("lucro-prejuizo/{clienteId}")]
    public async Task<IActionResult> LucroPrejuizo(int clienteId)
    {
    var resultado = await _service.ObterLucroPrejuizoAsync(clienteId);

    if (resultado == null)
        return NotFound(new { message = "Cliente sem custódia" });

    return Ok(resultado);
    }


    [HttpGet("posicao/{clienteId}")]
    public async Task<IActionResult> ObterPosicao(int clienteId)
    {
    var resultado = await _service.ObterPosicaoAsync(clienteId);

    if (resultado == null || !resultado.Any())
        return NotFound(new { message = "Nenhuma posição encontrada para o cliente" });

    return Ok(resultado);
    }

    [HttpPost("importar")]
    public async Task<IActionResult> Importar([FromQuery] string caminho)
    {
    if (string.IsNullOrEmpty(caminho))
        return BadRequest(new { message = "Caminho do arquivo é obrigatório" });

    await _importService.ImportarAsync(caminho);

    return Ok(new { message = "Importação concluída com sucesso" });
    }

    private readonly CotacaoImportService _importService;

    public ProcessamentoController(
    IProcessamentoService service,
    CotacaoImportService importService)
    {
    _service = service;
    _importService = importService;
    }

    

}
using CompraProgramada.Application.DTOs;

namespace CompraProgramada.Application.Interfaces;

public interface IProcessamentoService
{
    Task ProcessarComprasAsync(DateTime dataReferencia);
    Task ProcessarComprasConsolidadasAsync(DateTime data);
    Task<List<PosicaoDto>> ObterPosicaoAsync(int clienteId);
    Task<LucroPrejuizoDto?> ObterLucroPrejuizoAsync(int clienteId);

} 
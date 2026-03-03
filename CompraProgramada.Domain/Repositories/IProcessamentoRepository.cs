using CompraProgramada.Domain.Entities;


namespace CompraProgramada.Domain.Repositories;

public interface IProcessamentoRepository
{
    Task<List<Cliente>> ObterClientesAtivosAsync();
    Task<Cotacao?> ObterCotacaoPorDataAsync(DateTime data);
    Task<Custodia?> ObterCustodiaAsync(int contaFilhoteId, string ticker);
    Task AdicionarCustodiaAsync(Custodia custodia);
    Task<List<Custodia>> ObterCustodiasPorClienteAsync(int clienteId);
    Task<Cotacao?> ObterUltimaCotacaoAsync();
    //Task<Cesta?> ObterUltimaCestaAsync();
    Task<CestaTopFive?> ObterUltimaCestaAsync();
    Task AdicionarOrdemMasterAsync(OrdemMaster ordem);
    Task AdicionarOrdemClienteAsync(OrdemCliente ordem);
    Task SalvarAsync();
}
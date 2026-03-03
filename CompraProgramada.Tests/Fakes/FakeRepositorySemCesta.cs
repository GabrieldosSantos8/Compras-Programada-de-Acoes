using CompraProgramada.Domain.Repositories;
using CompraProgramada.Domain.Entities;

namespace CompraProgramada.Tests.Fakes;

public class FakeRepositorySemCesta : IProcessamentoRepository
{
    public Task<List<Cliente>> ObterClientesAtivosAsync()
        => Task.FromResult(new List<Cliente>
        {
            new Cliente("Teste", "123", "teste@email.com", 300m)
        });

    public Task<Cotacao?> ObterCotacaoPorDataAsync(DateTime data)
        => Task.FromResult<Cotacao?>(
            new Cotacao("PETR4", data, 30m)
        );

    public Task<CestaTopFive?> ObterUltimaCestaAsync()
        => Task.FromResult<CestaTopFive?>(null);

    public Task AdicionarOrdemMasterAsync(OrdemMaster ordem) => Task.CompletedTask;
    public Task AdicionarOrdemClienteAsync(OrdemCliente ordem) => Task.CompletedTask;
    public Task SalvarAsync() => Task.CompletedTask;

    public Task<Cotacao?> ObterUltimaCotacaoAsync() => Task.FromResult<Cotacao?>(null);
    public Task<Custodia?> ObterCustodiaAsync(int id, string ticker) => Task.FromResult<Custodia?>(null);
    public Task<List<Custodia>> ObterCustodiasPorClienteAsync(int id) => Task.FromResult(new List<Custodia>());
    public Task AdicionarCustodiaAsync(Custodia c) => Task.CompletedTask;
}
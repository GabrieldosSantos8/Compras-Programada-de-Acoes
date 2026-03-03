using CompraProgramada.Domain.Repositories;
using CompraProgramada.Domain.Entities;

namespace CompraProgramada.Tests.Fakes;
public class FakeRepositorySemClientes : IProcessamentoRepository
{
    public bool Salvou { get; private set; }

    public Task<List<Cliente>> ObterClientesAtivosAsync()
        => Task.FromResult(new List<Cliente>());

    public Task<Cotacao?> ObterCotacaoPorDataAsync(DateTime data)
        => Task.FromResult<Cotacao?>(
            new Cotacao("PETR4", data, 30m)
        );

    public Task<CestaTopFive?> ObterUltimaCestaAsync()
    {
        var itens = new List<ItemCesta>
        {
            new ItemCesta("PETR4", 20),
            new ItemCesta("VALE3", 20),
            new ItemCesta("ITUB4", 20),
            new ItemCesta("BBDC4", 20),
            new ItemCesta("ABEV3", 20),
        };

        return Task.FromResult<CestaTopFive?>(
            new CestaTopFive(DateTime.Today, itens)
        );
    }

    public Task SalvarAsync()
    {
        Salvou = true;
        return Task.CompletedTask;
    }

    // Restante vazio
    public Task AdicionarOrdemMasterAsync(OrdemMaster ordem) => Task.CompletedTask;
    public Task AdicionarOrdemClienteAsync(OrdemCliente ordem) => Task.CompletedTask;
    public Task<Cotacao?> ObterUltimaCotacaoAsync() => Task.FromResult<Cotacao?>(null);
    public Task<Custodia?> ObterCustodiaAsync(int id, string ticker) => Task.FromResult<Custodia?>(null);
    public Task<List<Custodia>> ObterCustodiasPorClienteAsync(int id) => Task.FromResult(new List<Custodia>());
    public Task AdicionarCustodiaAsync(Custodia c) => Task.CompletedTask;
}
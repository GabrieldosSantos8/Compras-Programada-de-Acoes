using CompraProgramada.Application.Services;
using CompraProgramada.Domain.Repositories;
using CompraProgramada.Domain.Entities;
using Xunit;

using CompraProgramada.Tests.Fakes;

namespace CompraProgramada.Tests.Application;

public class ProcessamentoServiceTests
{
    [Fact]
    public async Task Nao_Deve_Processar_Sem_Cesta()
    {
        var fakeRepo = new FakeRepositorySemCesta();
        var service = new ProcessamentoService(fakeRepo);

        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            service.ProcessarComprasConsolidadasAsync(DateTime.Today));
    }

    [Fact]
    public async Task Deve_Processar_Quando_Cesta_E_Clientes_Existirem()
    {
        var fakeRepo = new FakeRepositoryComCesta();
        var service = new ProcessamentoService(fakeRepo);

        await service.ProcessarComprasConsolidadasAsync(DateTime.Today);

        Assert.True(fakeRepo.OrdemMasterAdicionada);
        Assert.True(fakeRepo.OrdemClienteAdicionada);
        Assert.True(fakeRepo.Salvou);
    }

    [Fact]
    public async Task Nao_Deve_Processar_Sem_Clientes()
    {
        var fakeRepo = new FakeRepositorySemClientes();
        var service = new ProcessamentoService(fakeRepo);

        await Assert.ThrowsAsync<InvalidOperationException>(() =>
        service.ProcessarComprasConsolidadasAsync(DateTime.Today));

        Assert.False(fakeRepo.Salvou);
    }
}
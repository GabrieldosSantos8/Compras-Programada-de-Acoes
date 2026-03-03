using CompraProgramada.Application.Interfaces;
using CompraProgramada.Application.DTOs;
using System.Linq;
using CompraProgramada.Domain.Entities;
using System;
using CompraProgramada.Domain.Repositories;

namespace CompraProgramada.Application.Services;

public class ProcessamentoService : IProcessamentoService
{
    private readonly IProcessamentoRepository _repository;

    public ProcessamentoService(IProcessamentoRepository repository)
    {
        _repository = repository;
    }

    public async Task ProcessarComprasAsync(DateTime dataReferencia)
    {
        var clientesAtivos = await _repository.ObterClientesAtivosAsync();

        foreach (var cliente in clientesAtivos)
        {
            var cotacao = await _repository.ObterCotacaoPorDataAsync(dataReferencia);

            if (cotacao == null)
                throw new Exception($"Cotação não encontrada para {dataReferencia:dd/MM/yyyy}");

            var quantidade = (int)(cliente.ValorMensal / cotacao.PrecoFechamento);

            if (quantidade <= 0)
                continue;

            var custodia = await _repository
                .ObterCustodiaAsync(cliente.Id, cotacao.Ticker);

            if (custodia == null)
            {
                custodia = new Custodia(cliente.Id, cotacao.Ticker);
                await _repository.AdicionarCustodiaAsync(custodia);
            }
            custodia.Comprar(quantidade, cotacao.PrecoFechamento);
           
        }

        await _repository.SalvarAsync();
    }

    public async Task<LucroPrejuizoDto?> ObterLucroPrejuizoAsync(int clienteId)
    {
    var custodias = await _repository.ObterCustodiasPorClienteAsync(clienteId);

    var custodia = custodias.FirstOrDefault();

    if (custodia == null)
        return null;

    var cotacao = await _repository.ObterUltimaCotacaoAsync();

    if (cotacao == null)
        throw new Exception("Cotação não encontrada");

    return new LucroPrejuizoDto
    {
        Ticker = custodia.Ticker,
        Quantidade = custodia.Quantidade,
        PrecoMedio = custodia.PrecoMedio,
        PrecoAtual = cotacao.PrecoFechamento
    };
    }
    public async Task ProcessarComprasConsolidadasAsync(DateTime data)
    {
    var cesta = await _repository.ObterUltimaCestaAsync();

    if (cesta == null)
        throw new InvalidOperationException("Nenhuma cesta cadastrada.");

    var clientes = await _repository.ObterClientesAtivosAsync();

    if (!clientes.Any())
         throw new InvalidOperationException("Nenhum cliente ativo encontrado.");
        //return;

    var aportes = clientes
        .Select(c => new
        {
            Cliente = c,
            Valor = c.ValorMensal / 3m
        })
        .Where(x => x.Valor > 0)
        .ToList();

    var totalConsolidado = aportes.Sum(x => x.Valor);

    if (totalConsolidado == 0)
        return;

    foreach (var item in cesta.Itens)
    {
        var valorAtivo = totalConsolidado * (item.Percentual / 100m);

        await _repository.AdicionarOrdemMasterAsync(
            new OrdemMaster(data, item.Ticker, valorAtivo)
        );

        foreach (var aporte in aportes)
        {
            var valorCliente = aporte.Valor * (item.Percentual / 100m);

            await _repository.AdicionarOrdemClienteAsync(
                new OrdemCliente(aporte.Cliente.Id, item.Ticker, valorCliente, data)
            );
        }
    }

    await _repository.SalvarAsync();
    }

    /*
    public async Task ProcessarComprasConsolidadasAsync(DateTime data)
    {
    var clientes = await _repository.ObterClientesAtivosAsync();

    if (!clientes.Any())
        return;

    var aportes = clientes
        .Select(c => new
        {
            Cliente = c,
            Valor = c.ValorMensal / 3m
        })
        .Where(x => x.Valor > 0)
        .ToList();

    var totalConsolidado = aportes.Sum(x => x.Valor);

    if (totalConsolidado == 0)
        return;

    var cesta = await _repository.ObterUltimaCestaAsync();

    if (cesta == null)
        throw new Exception("Nenhuma cesta cadastrada.");

    foreach (var item in cesta.Itens)
    {
        var valorAtivo = totalConsolidado * (item.Percentual / 100m);

        await _repository.AdicionarOrdemMasterAsync(
            new OrdemMaster(data, item.Ticker, valorAtivo)
        );

        foreach (var aporte in aportes)
        {
            var valorCliente = aporte.Valor * (item.Percentual / 100m);

            await _repository.AdicionarOrdemClienteAsync(
                new OrdemCliente(aporte.Cliente.Id, item.Ticker, valorCliente, data)
            );
        }
    }

    await _repository.SalvarAsync();
    }
    */
    public async Task<List<PosicaoDto>> ObterPosicaoAsync(int clienteId)
    {
      var clientes = await _repository.ObterClientesAtivosAsync();

      var clienteExiste = clientes.Any(c => c.Id == clienteId);

        if (!clienteExiste)
        throw new Exception("Cliente não encontrado ou inativo");

        var custodias = await _repository.ObterCustodiasPorClienteAsync(clienteId);

        return custodias.Select(c => new PosicaoDto
        {
            Ticker = c.Ticker,
            Quantidade = c.Quantidade,
            PrecoMedio = c.PrecoMedio
        }).ToList();
    }
}
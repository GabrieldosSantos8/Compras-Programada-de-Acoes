using Microsoft.EntityFrameworkCore;
using CompraProgramada.Domain.Entities;
using CompraProgramada.Domain.Repositories;
using CompraProgramada.Infrastructure.Data;


namespace CompraProgramada.Infrastructure.Repositories;

public class ProcessamentoRepository : IProcessamentoRepository
{
    private readonly AppDbContext _context;

    public ProcessamentoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Cliente>> ObterClientesAtivosAsync()
    {
        return await _context.Clientes
            .Where(c => c.Ativo)
            .ToListAsync();
    }

    public async Task<Cotacao?> ObterCotacaoPorDataAsync(DateTime data)
    {
        return await _context.Cotacoes
            .Where(c => c.DataPregao.Date == data.Date)
            .FirstOrDefaultAsync();
    }

    public async Task<Custodia?> ObterCustodiaAsync(int contaFilhoteId, string ticker)
    {
        return await _context.Custodias
            .FirstOrDefaultAsync(c =>
                c.ContaFilhoteId == contaFilhoteId &&
                c.Ticker == ticker);
    }
    public async Task<List<Custodia>> ObterCustodiasPorClienteAsync(int clienteId)
    {
    return await _context.Custodias
        .Where(c => c.ContaFilhoteId == clienteId)
        .ToListAsync();
    }
    public async Task AdicionarCustodiaAsync(Custodia custodia)
    {
        await _context.Custodias.AddAsync(custodia);
    }

    public async Task<Cotacao?> ObterUltimaCotacaoAsync()
    {
    return await _context.Cotacoes
        .OrderByDescending(c => c.DataPregao)
        .FirstOrDefaultAsync();
    }
/*
    public async Task<Cesta?> ObterUltimaCestaAsync()
    {
    return await _context.Cestas
        .Include(c => c.Itens)
        .OrderByDescending(c => c.DataCriacao)
        .FirstOrDefaultAsync();
    }
*/
    public async Task<CestaTopFive?> ObterUltimaCestaAsync()
    {
    return await _context.Cestas
        .Include(c => c.Itens)
        .OrderByDescending(c => c.DataVigencia)
        .FirstOrDefaultAsync();
    }
    public async Task AdicionarOrdemMasterAsync(OrdemMaster ordem)
    {
    await _context.OrdensMaster.AddAsync(ordem);
    }

    public async Task AdicionarOrdemClienteAsync(OrdemCliente ordem)
    {
    await _context.OrdensClientes.AddAsync(ordem);
    }

    public async Task SalvarAsync()
    {
        await _context.SaveChangesAsync();
    }
}
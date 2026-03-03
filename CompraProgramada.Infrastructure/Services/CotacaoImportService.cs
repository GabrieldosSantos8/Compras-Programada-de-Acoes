using CompraProgramada.Domain.Entities;
using CompraProgramada.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace CompraProgramada.Infrastructure.Services;

public class CotacaoImportService
{
    
    private readonly AppDbContext _context;

    public CotacaoImportService(AppDbContext context)
    {
        _context = context;
    }

    
    public async Task ImportarAsync(string caminhoArquivo)
    {
        var cotacoes = new List<Cotacao>();
        var linhas = await File.ReadAllLinesAsync(caminhoArquivo);
    foreach (var linha in linhas)
    {
    if (!linha.StartsWith("01"))
        continue;

    var dataString = linha.Substring(2, 8);
    var ticker = linha.Substring(12, 12).Trim();
    var precoString = linha.Substring(108, 13);

    var data = DateTime.ParseExact(dataString, "yyyyMMdd", CultureInfo.InvariantCulture);
    var preco = decimal.Parse(precoString) / 100;

    bool existe = await _context.Cotacoes
        .AnyAsync(c => c.Ticker == ticker && c.DataPregao == data);

    if (!existe)
        cotacoes.Add(new Cotacao(ticker, data, preco));
    }

_context.Cotacoes.AddRange(cotacoes);
await _context.SaveChangesAsync();
        /*

        var linhas = await File.ReadAllLinesAsync(caminhoArquivo);

        foreach (var linha in linhas)
        {
            if (!linha.StartsWith("01"))
                continue;

            var dataString = linha.Substring(2, 8);
            var ticker = linha.Substring(12, 12).Trim();
            var precoString = linha.Substring(108, 13);

            var data = DateTime.ParseExact(dataString, "yyyyMMdd", CultureInfo.InvariantCulture);
            var preco = decimal.Parse(precoString) / 100;

            var cotacao = new Cotacao(ticker, data, preco);

            _context.Cotacoes.Add(cotacao);
        }

        await _context.SaveChangesAsync();
        */
    }
}
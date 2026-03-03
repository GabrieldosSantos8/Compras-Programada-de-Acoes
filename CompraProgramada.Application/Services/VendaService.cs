using CompraProgramada.Domain.Entities;
using CompraProgramada.Domain.Events;
using CompraProgramada.Domain.Services;
using CompraProgramada.Application.Interfaces;

namespace CompraProgramada.Application.Services;

public class VendaService
{
    private readonly CalculoImpostoService _impostoService;
    private readonly IEventPublisher _publisher;

    public VendaService(
        CalculoImpostoService impostoService,
        IEventPublisher publisher)
    {
        _impostoService = impostoService;
        _publisher = publisher;
    }

    public async Task VenderAsync(
        Custodia custodia,
        int quantidade,
        decimal precoVenda)
    {
        if (custodia is null)
            throw new ArgumentNullException(nameof(custodia));

        var valorVenda = quantidade * precoVenda;

        custodia.Vender(quantidade);

        var irDedoDuro = _impostoService.CalcularIrDedoDuro(valorVenda);

        var evento = new IrDedoDuroEvent(
            custodia.ContaFilhoteId,
            custodia.Ticker,
            valorVenda,
            irDedoDuro
        );

        await _publisher.PublishAsync("ir-dedo-duro", evento);
    }
}
namespace CompraProgramada.Domain.Events;

public class IrDedoDuroEvent
{
    public int ContaFilhoteId { get; }
    public string Ticker { get; }
    public decimal ValorVenda { get; }
    public decimal ValorIrRetido { get; }
    public DateTime Data { get; }

    public IrDedoDuroEvent(
        int contaFilhoteId,
        string ticker,
        decimal valorVenda,
        decimal valorIrRetido)
    {
        ContaFilhoteId = contaFilhoteId;
        Ticker = ticker;
        ValorVenda = valorVenda;
        ValorIrRetido = valorIrRetido;
        Data = DateTime.UtcNow;
    }
}
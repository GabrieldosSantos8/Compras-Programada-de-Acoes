namespace CompraProgramada.Domain.Entities;

public class OrdemMaster
{
    public int Id { get; private set; }
    public DateTime Data { get; private set; }
    public string Ticker { get; private set; }
    public decimal ValorTotal { get; private set; }

    public OrdemMaster(DateTime data, string ticker, decimal valorTotal)
    {
        Data = data;
        Ticker = ticker;
        ValorTotal = valorTotal;
    }
}
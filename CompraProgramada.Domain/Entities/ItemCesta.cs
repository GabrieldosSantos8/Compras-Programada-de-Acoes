namespace CompraProgramada.Domain.Entities;

public class ItemCesta
{
    public int Id { get; private set; }
    public string Ticker { get; private set; }
    public decimal Percentual { get; private set; }

    public int CestaId { get; private set; }

    public ItemCesta(string ticker, decimal percentual)
    {
        Ticker = ticker;
        Percentual = percentual;
    }
}
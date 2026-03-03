namespace CompraProgramada.Domain.Entities;

public class OrdemCliente
{
    public int Id { get; private set; }
    public int ClienteId { get; private set; }
    public string Ticker { get; private set; }
    public decimal Valor { get; private set; }
    public DateTime Data { get; private set; }

    public OrdemCliente(int clienteId, string ticker, decimal valor, DateTime data)
    {
        ClienteId = clienteId;
        Ticker = ticker;
        Valor = valor;
        Data = data;
    }
}
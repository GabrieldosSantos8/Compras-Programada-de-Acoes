namespace CompraProgramada.Domain.Entities;

public class Cotacao
{
    public int Id { get; private set; }
    public string Ticker { get; private set; } = string.Empty;
    public DateTime DataPregao { get; private set; }
    public decimal PrecoFechamento { get; private set; }

    protected Cotacao() { }

    public Cotacao(string ticker, DateTime dataPregao, decimal precoFechamento)
    {
        Ticker = ticker;
        DataPregao = dataPregao;
        PrecoFechamento = precoFechamento;
    }
}
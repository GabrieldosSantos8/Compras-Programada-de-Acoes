namespace CompraProgramada.Domain.Entities;

public class Custodia
{
    public int Id { get; private set; }
    public int ContaFilhoteId { get; private set; }
    public string Ticker { get; private set; } = string.Empty;
    public int Quantidade { get; private set; }
    public decimal PrecoMedio { get; private set; }

    protected Custodia() { }

    public Custodia(int contaFilhoteId, string ticker)
    {
        ContaFilhoteId = contaFilhoteId;
        Ticker = ticker;
        Quantidade = 0;
        PrecoMedio = 0;
    }

    public void AtualizarPrecoMedio(int quantidadeNova, decimal precoUnitario)
    {
    if (quantidadeNova <= 0)
        throw new ArgumentException("Quantidade deve ser maior que zero");

    if (precoUnitario <= 0)
        throw new ArgumentException("Preço deve ser maior que zero");

    var totalAnterior = Quantidade * PrecoMedio;
    var totalNovo = quantidadeNova * precoUnitario;

    Quantidade += quantidadeNova;
    PrecoMedio = (totalAnterior + totalNovo) / Quantidade;
    }

    public void Vender(int quantidade)
    {
    if (quantidade <= 0)
        throw new ArgumentException("Quantidade inválida");

    if (quantidade > Quantidade)
        throw new InvalidOperationException("Quantidade insuficiente");

    Quantidade -= quantidade;
    }
}
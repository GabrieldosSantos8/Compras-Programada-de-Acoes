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
        if (string.IsNullOrWhiteSpace(ticker))
            throw new ArgumentException("Ticker inválido");

        ContaFilhoteId = contaFilhoteId;
        Ticker = ticker;
        Quantidade = 0;
        PrecoMedio = 0;
    }

    public void Comprar(int quantidadeNova, decimal precoUnitario)
    {
        if (quantidadeNova <= 0)
            throw new ArgumentException("Quantidade deve ser maior que zero");

        if (precoUnitario <= 0)
            throw new ArgumentException("Preço deve ser maior que zero");

        // Primeira compra
        if (Quantidade == 0)
        {
            Quantidade = quantidadeNova;
            PrecoMedio = precoUnitario;
            return;
        }

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

        // Se zerar posição, zera o preço médio
        if (Quantidade == 0)
            PrecoMedio = 0;
    }

    public decimal CalcularPL(decimal cotacaoAtual)
    {
        if (cotacaoAtual <= 0)
            throw new ArgumentException("Cotação inválida");

        return (cotacaoAtual - PrecoMedio) * Quantidade;
    }
}
using CompraProgramada.Domain.Entities;

namespace CompraProgramada.Domain.Entities;
public class CestaTopFive
{
    public int Id { get; private set; }
    public DateTime DataVigencia { get; private set; }

    public List<ItemCesta> Itens { get; private set; } = new();

    private CestaTopFive() { }

    public CestaTopFive(DateTime dataVigencia, List<ItemCesta> itens)
    {
        if (itens.Count != 5)
            throw new ArgumentException("A cesta deve conter 5 ativos.");

        if (itens.Sum(i => i.Percentual) != 100)
            throw new ArgumentException("A soma dos percentuais deve ser 100%.");

        DataVigencia = dataVigencia;
        Itens = itens;
    }
}
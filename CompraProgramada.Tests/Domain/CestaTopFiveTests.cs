using Xunit;
using CompraProgramada.Domain.Entities;

public class CestaTopFiveTests
{
    [Fact]
    public void Deve_Lancar_Excecao_Se_Nao_Tiver_5_Ativos()
    {
        var itens = new List<ItemCesta>
        {
            new ItemCesta("PETR4", 20),
            new ItemCesta("VALE3", 20)
        };

        Assert.Throws<ArgumentException>(() =>
            new CestaTopFive(DateTime.Today, itens));
    }

    [Fact]
    public void Deve_Lancar_Excecao_Se_Soma_Diferente_De_100()
    {
        var itens = new List<ItemCesta>
        {
            new ItemCesta("PETR4", 30),
            new ItemCesta("VALE3", 30),
            new ItemCesta("ITUB4", 30),
            new ItemCesta("ABEV3", 5),
            new ItemCesta("BBDC4", 4)
        };

        Assert.Throws<ArgumentException>(() =>
            new CestaTopFive(DateTime.Today, itens));
    }

    [Fact]
    public void Deve_Criar_Cesta_Valida()
    {
        var itens = new List<ItemCesta>
        {
            new ItemCesta("PETR4", 20),
            new ItemCesta("VALE3", 20),
            new ItemCesta("ITUB4", 20),
            new ItemCesta("ABEV3", 20),
            new ItemCesta("BBDC4", 20)
        };

        var cesta = new CestaTopFive(DateTime.Today, itens);

        Assert.NotNull(cesta);
        Assert.Equal(5, cesta.Itens.Count);
    }
}
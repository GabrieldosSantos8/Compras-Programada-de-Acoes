using CompraProgramada.Domain.Entities;
using Xunit;

namespace CompraProgramada.Tests.Domain;

public class CustodiaTests
{
    [Fact]
    public void Deve_Calcular_Preco_Medio_Corretamente()
    {
        var custodia = new Custodia(1, "PETR4");

        custodia.Comprar(100, 35m);
        custodia.Comprar(50, 38m);

        Assert.Equal(150, custodia.Quantidade);
        Assert.Equal(36m, custodia.PrecoMedio);
    }
}
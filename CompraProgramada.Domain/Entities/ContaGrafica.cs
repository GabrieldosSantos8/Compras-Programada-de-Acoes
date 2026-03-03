using CompraProgramada.Domain.Enums;

namespace CompraProgramada.Domain.Entities;

public class ContaGrafica
{
    public int Id { get; private set; }
    public int? ClienteId { get; private set; }
    public string NumeroConta { get; private set; } = string.Empty;
    public TipoConta Tipo { get; private set; }

    protected ContaGrafica() { }

    public ContaGrafica(string numeroConta, TipoConta tipo, int? clienteId = null)
    {
        NumeroConta = numeroConta;
        Tipo = tipo;
        ClienteId = clienteId;
    }
}
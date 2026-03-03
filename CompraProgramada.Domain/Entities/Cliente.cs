namespace CompraProgramada.Domain.Entities;

public class Cliente
{
    public int Id { get; private set; }
    public string Nome { get; private set; } = string.Empty;
    public string CPF { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public decimal ValorMensal { get; private set; }
    public bool Ativo { get; private set; }
    public DateTime DataAdesao { get; private set; }

    protected Cliente() { }

    public Cliente(string nome, string cpf, string email, decimal valorMensal)
    {
        if (valorMensal < 100)
            throw new ArgumentException("Valor mínimo é 100");

        Nome = nome;
        CPF = cpf;
        Email = email;
        ValorMensal = valorMensal;
        Ativo = true;
        DataAdesao = DateTime.UtcNow;
    }

    public decimal ObterValorParcela()
        => ValorMensal / 3m;

    public void AlterarValorMensal(decimal novoValor)
    {
        if (novoValor < 100)
            throw new ArgumentException("Valor mínimo é 100");

        ValorMensal = novoValor;
    }

    public void Desativar()
        => Ativo = false;
}
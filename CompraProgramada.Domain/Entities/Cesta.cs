namespace CompraProgramada.Domain.Entities;

public class Cesta
{
    public int Id { get; private set; }
    public DateTime DataCriacao { get; private set; }

    public List<ItemCesta> Itens { get; private set; } = new();

    public Cesta()
    {
        DataCriacao = DateTime.Now;
    }
}
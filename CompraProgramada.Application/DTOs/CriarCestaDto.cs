namespace CompraProgramada.Application.DTOs;

public class CriarCestaDto
{
    public List<ItemCestaDto> Itens { get; set; } = new();
}

public class ItemCestaDto
{
    public string Ticker { get; set; } = string.Empty;
    public decimal Percentual { get; set; }
}
namespace CompraProgramada.Application.DTOs;

public class PosicaoDto
{
    public string Ticker { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public decimal PrecoMedio { get; set; }
    public decimal ValorTotal => Quantidade * PrecoMedio;
}
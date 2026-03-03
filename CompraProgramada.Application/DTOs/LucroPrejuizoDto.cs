namespace CompraProgramada.Application.DTOs;

public class LucroPrejuizoDto
{
    public string Ticker { get; set; } = string.Empty;
    public int Quantidade { get; set; }
    public decimal PrecoMedio { get; set; }
    public decimal PrecoAtual { get; set; }
    public decimal Resultado => (PrecoAtual - PrecoMedio) * Quantidade;
}
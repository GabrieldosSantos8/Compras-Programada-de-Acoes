namespace CompraProgramada.Application.DTOs;

public class CreateClienteDto
{
    public string Nome { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public decimal ValorMensal { get; set; }
}
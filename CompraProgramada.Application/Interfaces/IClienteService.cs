using CompraProgramada.Application.DTOs;

namespace CompraProgramada.Application.Interfaces;

public interface IClienteService
{
    Task<int> CriarClienteAsync(CreateClienteDto dto);
}
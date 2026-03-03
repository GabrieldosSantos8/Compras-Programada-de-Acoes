using CompraProgramada.Domain.Entities;

namespace CompraProgramada.Domain.Repositories;

public interface IClienteRepository
{
    Task<bool> ExisteCpfAsync(string cpf);
    Task AdicionarAsync(Cliente cliente);
    Task SalvarAsync();
}
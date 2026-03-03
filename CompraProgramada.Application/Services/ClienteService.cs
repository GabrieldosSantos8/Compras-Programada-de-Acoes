using CompraProgramada.Application.DTOs;
using CompraProgramada.Application.Interfaces;
using CompraProgramada.Domain.Entities;
using CompraProgramada.Domain.Repositories;

namespace CompraProgramada.Application.Services;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _repository;

    public ClienteService(IClienteRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> CriarClienteAsync(CreateClienteDto dto)
    {
        if (await _repository.ExisteCpfAsync(dto.CPF))
            throw new Exception("CPF já cadastrado.");

        var cliente = new Cliente(
            dto.Nome,
            dto.CPF,
            dto.Email,
            dto.ValorMensal
        );

        await _repository.AdicionarAsync(cliente);
        await _repository.SalvarAsync();

        return cliente.Id;
    }
}
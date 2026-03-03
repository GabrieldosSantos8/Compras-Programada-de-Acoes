using Microsoft.EntityFrameworkCore;
using CompraProgramada.Domain.Entities;
using CompraProgramada.Domain.Repositories;
using CompraProgramada.Infrastructure.Data;

namespace CompraProgramada.Infrastructure.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly AppDbContext _context;

    public ClienteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ExisteCpfAsync(string cpf)
    {
        return await _context.Clientes
            .AnyAsync(c => c.CPF == cpf);
    }

    public async Task AdicionarAsync(Cliente cliente)
    {
        await _context.Clientes.AddAsync(cliente);
    }

    public async Task SalvarAsync()
    {
        await _context.SaveChangesAsync();
    }
}
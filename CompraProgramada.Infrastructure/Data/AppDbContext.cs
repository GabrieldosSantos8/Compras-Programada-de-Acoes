using Microsoft.EntityFrameworkCore;
using CompraProgramada.Domain.Entities;

namespace CompraProgramada.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<ContaGrafica> ContasGraficas => Set<ContaGrafica>();
    public DbSet<Custodia> Custodias => Set<Custodia>();
    public DbSet<Cotacao> Cotacoes => Set<Cotacao>();
    public DbSet<CestaTopFive> Cestas { get; set; }
    public DbSet<ItemCesta> ItensCesta { get; set; }
    public DbSet<OrdemMaster> OrdensMaster { get; set; }
    public DbSet<OrdemCliente> OrdensClientes { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.CPF).IsUnique();
            entity.Property(e => e.Nome).IsRequired().HasMaxLength(150);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(150);
        });

        modelBuilder.Entity<ContaGrafica>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.NumeroConta).IsRequired();
        });

        modelBuilder.Entity<Custodia>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Ticker).IsRequired().HasMaxLength(10);
        });

        modelBuilder.Entity<Cotacao>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => new { e.Ticker, e.DataPregao }).IsUnique();
        });

        base.OnModelCreating(modelBuilder);
    }
}
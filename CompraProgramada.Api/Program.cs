using Microsoft.EntityFrameworkCore;
using CompraProgramada.Infrastructure.Data;
using CompraProgramada.Application.Interfaces;
using CompraProgramada.Application.Services;
using CompraProgramada.Domain.Repositories;
using CompraProgramada.Infrastructure.Repositories;
using CompraProgramada.Api.Middlewares;
using CompraProgramada.Infrastructure.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<CotacaoImportService>();
builder.Services.AddScoped<IProcessamentoRepository, ProcessamentoRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IProcessamentoService, ProcessamentoService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
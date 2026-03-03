📌 Compra Programada API

API responsável pelo processamento de compras programadas de ativos financeiros, geração de ordens consolidadas, atualização de custódia, cálculo de imposto de renda e publicação de eventos.

🏗 Arquitetura

O projeto foi desenvolvido utilizando princípios de Clean Architecture, com separação clara de responsabilidades entre as camadas:

Domain → Entidades e regras de negócio

Application → Casos de uso e orquestração

Infrastructure → Persistência, repositórios e mensageria

API → Exposição dos endpoints e configuração da aplicação

Essa abordagem reduz acoplamento, facilita testes e melhora a manutenibilidade do sistema.

📂 Estrutura de Pastas (Solution Layout)
CompraProgramada.sln
│
├── CompraProgramada.Api
│   ├── Controllers
│   ├── Middlewares
│   └── Program.cs
│
├── CompraProgramada.Application
│   ├── DTOs
│   ├── Interfaces
│   └── Services
│
├── CompraProgramada.Domain
│   ├── Entities
│   ├── Repositories
│   └── Services
│
├── CompraProgramada.Infrastructure
│   ├── Data
│   ├── Repositories
│   ├── Messaging
│   └── Services
│
└── CompraProgramada.Tests
    └── Testes unitários (xUnit)
    
🧩 Principais Funcionalidades

Processamento de compras consolidadas

Geração de Ordem Master

Geração de Ordens por Cliente

Atualização de custódia com cálculo de preço médio

Cálculo de imposto de renda

Geração de relatório mensal

Publicação de eventos (estrutura preparada para Kafka)

Testes unitários cobrindo cenários críticos

🧠 Regras de Negócio Implementadas

Validação de clientes ativos

Validação de existência de cesta válida

Cálculo correto de preço médio ponderado

Atualização de custódia por cliente

Geração consolidada de ordens

Tratamento global de erros via middleware

🧪 Testes

Foram implementados testes unitários utilizando xUnit, validando:

Não processar sem clientes

Não processar sem cesta

Processamento correto em cenário válido

Executar testes:

dotnet test
🚀 Executando o Projeto
🔧 Build
dotnet build
▶ Executar API
dotnet run --project CompraProgramada.Api

Swagger disponível em:

https://localhost:{porta}/swagger
🐳 Executar com Docker
docker-compose up --build
🛠 Tecnologias Utilizadas

.NET 8

ASP.NET Core

Entity Framework Core

MySQL

xUnit

Swagger

Docker

📌 Decisões Técnicas

Separação clara entre domínio e infraestrutura

Inversão de dependência via interfaces

Encapsulamento das regras críticas no Domain

Preparação para mensageria baseada em eventos

Estrutura orientada a testabilidade

📈 Evoluções Futuras

Implementação de mensageria real com Kafka

Controle transacional mais robusto

Estratégias de idempotência

Autenticação e autorização (JWT)

Observabilidade (logs estruturados)

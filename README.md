# 💼 Compra Programada - Processamento de Investimentos

Projeto desenvolvido em .NET 8 simulando o processamento de compras programadas de ativos financeiros com base em uma cesta Top Five.

## 📌 Objetivo

Processar compras consolidadas para clientes ativos, distribuindo investimentos conforme uma cesta pré-definida de ativos.

O sistema valida:

- Existência de cesta ativa
- Existência de clientes ativos
- Cotação disponível
- Atualização de custódia
- Geração de ordem master
- Geração de ordens por cliente

---

## 🏗 Arquitetura

O projeto foi estruturado seguindo princípios de separação de responsabilidades:

CompraProgramada
│
├── CompraProgramada.Domain → Entidades e Interfaces
├── CompraProgramada.Application → Regras de Negócio
└── CompraProgramada.Tests → Testes unitários (xUnit)


### 🔹 Domain
Contém:
- Entidades
- Interfaces de repositório
- Regras puras de negócio

### 🔹 Application
Contém:
- `ProcessamentoService`
- Orquestração do fluxo de processamento

### 🔹 Tests
Contém:
- Testes unitários com xUnit
- Fakes para simular cenários:
  - Sem cesta
  - Sem clientes
  - Fluxo válido

---

## 🧪 Testes

Cobertura de cenários:

- ❌ Não processar sem cesta
- ❌ Não processar sem clientes
- ✅ Processar corretamente com cesta válida

Executar testes:

```bash
dotnet test
````

🚀 Tecnologias Utilizadas

.NET 8

C#

xUnit

Arquitetura em camadas

Injeção de Dependência

Princípios SOLID

▶ Como Executar

Restaurar dependências:

dotnet restore

Rodar testes:

dotnet test
📎 Considerações Técnicas

Uso de repositório via interface para facilitar testes.

Uso de Fakes ao invés de banco real para testes unitários.

Validações explícitas para garantir integridade do processamento.

Separação clara entre domínio e aplicação.

👨‍💻 Autor

Gabriel Santos
Bacharel em Sistemas de Informação
Pós-graduação em Engenharia de Software



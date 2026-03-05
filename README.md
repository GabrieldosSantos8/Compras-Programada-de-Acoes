📌 Compra Programada API - Desafio Técnico Itaú
Esta API é uma solução robusta para o processamento de compras programadas de ativos financeiros, realizando a consolidação de ordens, gestão de custódia e cálculo de performance de carteira.

🏗️ Arquitetura e Tecnologias
O projeto foi desenvolvido seguindo os princípios de Clean Architecture e DDD (Domain-Driven Design), garantindo alta testabilidade e baixo acoplamento.

Linguagem: C# (.NET 8)

Banco de Dados: MySQL

ORM: Entity Framework Core (com Migrations)

Mensageria: Arquitetura preparada para integração com Kafka (processamento de eventos).

Camadas do Projeto:

Domain: Entidades, interfaces de repositório e regras de negócio puras.

Application: Casos de uso, DTOs e serviços de orquestração.

Infrastructure: Implementação de persistência, contextos de dados e comunicação externa.

API: Controllers, Middlewares de erro global e documentação Swagger.

🧪 Testes e Qualidade

Framework: Implementação de testes unitários com xUnit.

Cenários Críticos: Validação de fluxo de caixa, existência de cestas, cálculo de preço médio ponderado e integridade do rateio de ativos.

Execução: Para rodar os testes, utilize o comando: 
```bash
dotnet test
````

🧠 Regras de Negócio e Domínio Financeiro

Consolidação de Ordens: Agrupamento de intenções de compra individuais em uma Ordem Master para otimização de execução no mercado.

Lógica de Rateio Proporcional: Distribuição precisa de ativos entre clientes baseada no aporte mensal, com tratamento técnico de resíduos na Conta Master.

Mark-to-Market (MTM): Motor de cálculo de performance comparando o Preço Médio de aquisição com a cotação atual do pregão.

🗄️ Guia de Auditoria do Banco de Dados (MySQL)
Utilize as queries abaixo para validar a integridade dos dados e os cálculos realizados pelo sistema:

1. Visualização Geral das Entidades
   
SQL
```bash
SELECT * FROM clientes;
SELECT * FROM cotacoes;
SELECT * FROM custodias;
SELECT * FROM ordensmaster;
SELECT * FROM ordensclientes;
````
3. Posição de Custódia por Cliente
   
SQL
```bash
-- Exibe os ativos em carteira vinculados ao cliente
SELECT cli.Nome, c.Ticker, c.Quantidade, c.PrecoMedio
FROM Custodias c
INNER JOIN Clientes cli ON cli.Id = c.ContaFilhoteId
WHERE cli.Id = 2; -- Exemplo: Cliente ID 2
````
5. Relatório de Performance e Lucro/Prejuízo
   
SQL
```bash
SELECT 
    cli.Nome AS Cliente, 
    c.Ticker, 
    c.Quantidade AS Qtd, 
    c.PrecoMedio, 
    cot.PrecoFechamento AS PrecoAtual, 
    (c.Quantidade * cot.PrecoFechamento) AS ValorAtual, 
    ((cot.PrecoFechamento - c.PrecoMedio) * c.Quantidade) AS LucroPrejuizo, 
    (((cot.PrecoFechamento / c.PrecoMedio) - 1) * 100) AS PerformancePorcentagem 
FROM custodias c
INNER JOIN clientes cli ON cli.Id = c.ContaFilhoteId
INNER JOIN cotacoes cot ON cot.Ticker = c.Ticker
WHERE cot.DataPregao = (SELECT MAX(DataPregao) FROM cotacoes WHERE Ticker = c.Ticker)
ORDER BY LucroPrejuizo DESC;
````
🚀 Como Executar o Projeto
Configure a Connection String do seu MySQL no arquivo appsettings.json.

Execute o comando para build:
```bash
dotnet build
````
Inicie a API:
```bash
dotnet run --project CompraProgramada.Api
````
Acesse a documentação interativa via Swagger em:
```bash
https://localhost:{porta}/swagger
````
📈 Roadmap de Escalabilidade (Diferenciais)
O sistema foi desenhado para evoluir em ambiente de produção com:

Implementação de Idempotência no processamento de ordens.

Integração real com broker de mensagens (Kafka).

Logs estruturados para Observabilidade (Serilog/ELK).

Autenticação via JWT (OAuth2).

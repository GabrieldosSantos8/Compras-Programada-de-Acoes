# Desafio Técnico: Sistema de Compra Programada de Ações

Este projeto é uma solução para o gerenciamento de compras programadas, custódia e processamento de ordens de ativos financeiros.

## 🛠️ Tecnologias Utilizadas
* **Linguagem:** C# (.NET 8)
* **Banco de Dados:** MySQL
* **ORM:** Entity Framework Core (Migrations)
* **Mensageria:** Kafka (Infraestrutura preparada)

## 🗄️ Guia do Banco de Dados (MySQL)

Para validar o funcionamento do sistema e os resultados do processamento, utilize as consultas SQL abaixo:

### 1. Visualização das Tabelas Base
Consulte os dados brutos populados pelas migrations e serviços:
```sql
SELECT * FROM clientes;
SELECT * FROM cotacoes;
SELECT * FROM custodias;
SELECT * FROM cestas;
SELECT * FROM ordensmaster;
````
2. Posição Consolidada do Cliente
Exibe os ativos em carteira (custódia) vinculados ao nome do cliente:

````SQL
-- posição do cliente (custódia + cliente)
SELECT 
    cli.Nome, 
    c.Ticker, 
    c.Quantidade, 
    c.PrecoMedio
FROM Custodias c
INNER JOIN Clientes cli ON cli.Id = c.ContaFilhoteId
WHERE cli.Id = 2; -- Altere o ID conforme necessário
````
3. Relatório de Performance (Mark-to-Market)
Calcula o lucro/prejuízo e a performance percentual comparando o preço médio com a cotação mais recente:

````SQL
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
4. Ordens Consolidadas
Relaciona as ordens mestres com as ordens individuais de cada cliente:


````SQL
-- ordens consolidadas (OrdemMaster + OrdemCliente)
SELECT 
    om.id AS OrdemMasterId, 
    om.ticker, 
    om.data, 
    om.valortotal, 
    oc.id AS OrdemClienteId, 
    oc.clienteid, 
    oc.valor
FROM ordensmaster om
INNER JOIN ordensclientes oc ON om.ticker = oc.ticker;
````
🚀 Como Executar
Configure a connection string do MySQL no arquivo appsettings.json.


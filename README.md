\# 💳 TransacaoFinanceira



Case técnico para refatoração de um sistema de transações financeiras.



\---



\## 🎯 Objetivo do Case



Este projeto tem como objetivo refatorar um sistema legado de transações financeiras, aplicando boas práticas de desenvolvimento, correção de bugs e melhorias estruturais.



\---



\## 🧩 Descrição do Problema



O sistema original apresentava os seguintes problemas:



\- Erros de compilação

\- Inconsistência em transações financeiras

\- Transações sendo canceladas incorretamente mesmo com saldo disponível

\- Transações sendo aprovadas mesmo sem saldo suficiente

\- Ausência de boas práticas de arquitetura e design

\- Falta de testes automatizados



\---



\## 🛠️ Soluções Aplicadas



Durante a refatoração foram aplicados os seguintes ajustes:



\### ✔ Correções Funcionais

\- Ajuste de tipos de dados (int, long, decimal)

\- Correção na lógica de validação de saldo

\- Garantia de consistência nas operações de débito e crédito



\---



\### ✔ Refatoração de Código

\- Separação em camadas:

&#x20; - Entities

&#x20; - Services

&#x20; - Repositories

&#x20; - API

\- Aplicação de princípios \*\*SOLID\*\*

\- Redução de acoplamento entre camadas

\- Introdução de injeção de dependência (DI)



\---



\### ✔ Concorrência

\- Implementação de controle de concorrência com `lock`

\- Garantia de consistência em transferências simultâneas

\- Testes de concorrência com `Parallel.For`



\---



\### ✔ Logging

\- Substituição de `Console.WriteLine` por `ILogger`

\- Logs estruturados por nível:

&#x20; - Information

&#x20; - Warning

&#x20; - Error

\- Uso de `CorrelationId` para rastreabilidade



\---



\### ✔ Testes Unitários

Foram implementados testes utilizando \*\*xUnit + Moq\*\*, cobrindo:



\- Transferência com sucesso

\- Saldo insuficiente

\- Conta inválida

\- Execução concorrente



\---



\## 🧪 Como Executar os Testes



```bash

dotnet test


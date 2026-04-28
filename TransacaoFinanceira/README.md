# 💳 TransacaoFinanceira

## 🧾 Case para refatoração

---

## 📌 Passos a implementar

Corrija o que for necessario para resolver os erros de compilação.  
Execute o programa para avaliar a saida, identifique e corrija o motivo de algumas transacoes estarem sendo canceladas mesmo com saldo positivo e outras sem saldo sendo efetivadas.  
Aplique o code review e refatore conforme as melhores praticas (SOLID, Patterns, etc).  
Implemente os testes unitários que julgar efetivo.  
Crie um git hub e compartilhe o link respondendo o ultimo e-mail.  

**Obs:** Voce é livre para implementar na linguagem de sua preferência, desde que respeite as funcionalidades e saídas existentes, além de aplicar os conceitos solicitados.

---

# 🚀 Implementação Realizada

Durante a refatoração do sistema, foram aplicadas melhorias estruturais e correções de regra de negócio.

---

## 🧱 Arquitetura

O projeto foi reorganizado em uma arquitetura em camadas:

- Entities (domínio)
- Models (DTOs / resultados)
- Repositories (acesso a dados)
- Services (regras de negócio)
- API (exposição HTTP)
- Tests (testes automatizados)

---

## 🔧 Correções Realizadas

- Correção de inconsistência em transações financeiras
- Ajuste de tipos de dados (int → long → decimal conforme necessidade)
- Correção da lógica de validação de saldo
- Garantia de que transações inválidas não sejam processadas

---

## 🧠 Melhorias Aplicadas

- Aplicação de princípios **SOLID**
- Separação de responsabilidades entre camadas
- Uso de **Dependency Injection**
- Refatoração da regra de transferência para Service
- Introdução de contratos via interfaces

---

## 🔒 Concorrência

- Implementação de controle de concorrência com `lock`
- Garantia de consistência em transferências simultâneas
- Testes com execução paralela (`Parallel.For`)

---

## 📊 Logging

- Substituição de logs via console por `ILogger`
- Inclusão de `CorrelationId` para rastreabilidade
- Registro de sucesso e falhas de transações

---

## 🧪 Testes

Foram implementados testes com **xUnit + Moq**, cobrindo:

- Transferência com sucesso
- Saldo insuficiente
- Conta inválida
- Execução concorrente

---

## 🔮 Melhorias Futuras

- Substituir `lock` por solução distribuída (Redis)
- Persistência em banco de dados
- Mensageria (RabbitMQ/Kafka)
- Observabilidade com OpenTelemetry
- Implementação de CQRS

---

## 👨‍💻 Observação Final

O projeto foi evoluído com foco em boas práticas de engenharia de software, mantendo o comportamento original do sistema e garantindo consistência, escalabilidade e testabilidade.
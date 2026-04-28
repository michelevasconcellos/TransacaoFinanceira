using Microsoft.Extensions.Logging;
using TransacaoFinanceira.Models;
using TransacaoFinanceira.Repositories;

namespace TransacaoFinanceira.Services
{
    public class TransferenciaService : ITransferenciaService
    {
        private readonly IContaRepository _contaRepository;
        private readonly ILogger<TransferenciaService> _logger;
        private readonly object _lock = new object();

        public TransferenciaService(
            IContaRepository contaRepository,
            ILogger<TransferenciaService> logger)
        {
            _contaRepository = contaRepository;
            _logger = logger;
        }

        public TransferenciaResultado Transferir(int correlationId, long contaOrigem, long contaDestino, decimal valor)
        {
            _logger.LogInformation("Iniciando transação {CorrelationId}", correlationId);

            lock (_lock)
            {
                var origem = _contaRepository.Obter(contaOrigem);
                var destino = _contaRepository.Obter(contaDestino);

                if (origem == null || destino == null)
                {
                    _logger.LogWarning("Transação {CorrelationId} falhou: conta inválida", correlationId);

                    return new TransferenciaResultado
                    {
                        Sucesso = false,
                        Mensagem = "Conta inválida"
                    };
                }

                if (valor <= 0)
                {
                    _logger.LogWarning("Transação {CorrelationId} falhou: valor inválido", correlationId);

                    return new TransferenciaResultado
                    {
                        Sucesso = false,
                        Mensagem = "Valor inválido"
                    };
                }

                if (origem.Saldo < valor)
                {
                    _logger.LogWarning("Transação {CorrelationId} cancelada: saldo insuficiente", correlationId);

                    return new TransferenciaResultado
                    {
                        Sucesso = false,
                        Mensagem = "Saldo insuficiente"
                    };
                }

                origem.Debitar(valor);
                destino.Creditar(valor);

                _contaRepository.Atualizar(origem);
                _contaRepository.Atualizar(destino);

                _logger.LogInformation(
                    "Transação {CorrelationId} concluída com sucesso. Origem={Origem} Destino={Destino}",
                    correlationId,
                    origem.Saldo,
                    destino.Saldo
                );

                return new TransferenciaResultado
                {
                    Sucesso = true,
                    Mensagem = "Transferência realizada com sucesso"
                };
            }
        }
    }
}
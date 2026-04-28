using TransacaoFinanceira.Models;

namespace TransacaoFinanceira.Services
{
    public interface ITransferenciaService
    {
        TransferenciaResultado Transferir(int correlationId, long contaOrigem, long contaDestino, decimal valor);
    }
}
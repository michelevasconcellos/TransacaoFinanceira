namespace TransacaoFinanceira.Api.Models
{
    public class TransferenciaRequest
    {
        public int CorrelationId { get; set; }
        public long ContaOrigem { get; set; }
        public long ContaDestino { get; set; }
        public decimal Valor { get; set; }
    }
}
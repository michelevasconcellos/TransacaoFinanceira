

namespace TransacaoFinanceira.Entities
{
    public class ContaSaldo
    {
        public long Conta { get; set; }
        public decimal Saldo { get; set; }

        public ContaSaldo(long conta, decimal saldo)
        {
            Conta = conta;
            Saldo = saldo;
        }

        public void Debitar(decimal valor)
        {
            Saldo -= valor;
        }

        public void Creditar(decimal valor)
        {
            Saldo += valor;
        }
    }
}
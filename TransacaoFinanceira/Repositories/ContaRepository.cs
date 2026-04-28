using System.Collections.Generic;
using System.Linq;
using TransacaoFinanceira.Entities;

namespace TransacaoFinanceira.Repositories
{
    public class ContaRepository : IContaRepository
    {
        private readonly List<ContaSaldo> _contas;
        private readonly object _lock = new object();

        public ContaRepository()
        {
            _contas = new List<ContaSaldo>
                {
                    new ContaSaldo(938485762, 180),
                    new ContaSaldo(347586970, 1200),
                    new ContaSaldo(2147483649, 0),
                    new ContaSaldo(675869708, 4900),
                    new ContaSaldo(238596054, 478),
                    new ContaSaldo(573659065, 787),
                    new ContaSaldo(210385733, 10),
                    new ContaSaldo(674038564, 400),
                    new ContaSaldo(563856300, 1200)
                };
        }
        public ContaSaldo Obter(long conta)
        {
            lock (_lock)
            {
                return _contas.FirstOrDefault(x => x.Conta == conta);
            }
        }

        public void Atualizar(ContaSaldo conta)
        {
            lock (_lock)
            {
                var existente = _contas.FirstOrDefault(x => x.Conta == conta.Conta);

                if (existente != null)
                {
                    existente.Saldo = conta.Saldo;
                }
            }
        }
    }
}
using TransacaoFinanceira.Entities;

namespace TransacaoFinanceira.Repositories
{
    public interface IContaRepository
    {
        ContaSaldo Obter(long conta);
        void Atualizar(ContaSaldo conta);
    }
}

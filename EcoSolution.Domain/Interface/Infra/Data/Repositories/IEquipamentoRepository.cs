using EcoSolution.Domain.Entities;

namespace EcoSolution.Domain.Interface.Infra.Data.Repositories
{
    public interface IEquipamentoRepository
    {
        Task<Equipamento> InserirEquipamento(Equipamento entity);

        Task<IEnumerable<Equipamento>> BuscarEquipamentos();

        Task<Equipamento?> BuscarEquipamentoId(long equipamentoId);

        Task<Equipamento> AtualizarEquipamento(Equipamento entity);

        Task<bool> ExcluirEquipamento(long equipamentoId);
    }
}

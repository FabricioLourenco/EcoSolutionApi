using EcoSolution.Domain.Entities;

namespace EcoSolution.Domain.Interface.Infra.Data.Repositories
{
    public interface IManualRepository
    {
        Task<Manual> InserirManual(Manual entity);

        Task<IEnumerable<Manual>> BuscarManuais();

        Task<Manual?> BuscarManualId(long manualId);

        Task<Manual> AtualizarManual(Manual entity);

        Task<bool> ExcluirManual(long manualId);
    }
}

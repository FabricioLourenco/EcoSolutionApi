using EcoSolution.Domain.DTos;
using EcoSolution.Domain.Entities;

namespace EcoSolution.Domain.Interface.Application.Services
{
    public interface IManualService
    {
        Task<Manual> InserirManual(ManualDTo model);

        Task<List<Manual>> BuscarManuais();

        Task<Manual> AtualizarManual(ManualDTo model);

        Task<bool> ExcluirManual(long manualId);
    }
}

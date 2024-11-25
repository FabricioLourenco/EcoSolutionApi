using EcoSolution.Domain.DTos;
using EcoSolution.Domain.DTos.Base;
using EcoSolution.Domain.Entities;

namespace EcoSolution.Domain.Interface.Application.Services
{
    public interface IEquipamentoService
    {
        Task<Equipamento> InserirEquipamento(EquipamentoDTo model);

        Task<List<Equipamento>> BuscarEquipamentos();

        Task<Equipamento> AtualizarEquipamento(UpdateEquipamentoDTo model);

        Task<bool> ExcluirEquipamento(long equipamentoId);
    }
}

using EcoSolution.Domain.DTos;
using EcoSolution.Domain.Entities;

namespace EcoSolution.Domain.Interface.Application.Services
{
    public interface IMaterialService
    {
        Task<Material> InserirMaterial(MaterialDTo model);

        Task<List<Material>> BuscarMateriais();

        Task<Material> AtualizarMaterial(MaterialDTo model);

        Task<bool> ExcluirMaterial(long materialId);
    }
}

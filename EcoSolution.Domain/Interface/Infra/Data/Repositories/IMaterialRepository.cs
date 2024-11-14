using EcoSolution.Domain.Entities;

namespace EcoSolution.Domain.Interface.Infra.Data.Repositories
{
    public interface IMaterialRepository
    {
        Task<Material> InserirMaterial(Material entity);

        Task<IEnumerable<Material>> BuscarMateriais();

        Task<Material?> BuscarMaterialId(long materialId);

        Task<Material> AtualizarMaterial(Material entity);

        Task<bool> ExcluirMaterial(long materialId);
    }
}

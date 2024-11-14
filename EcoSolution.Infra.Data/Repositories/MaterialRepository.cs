using EcoSolution.Domain.Entities;
using EcoSolution.Domain.Interface.Infra.Data;
using EcoSolution.Domain.Interface.Infra.Data.Repositories;
using EcoSolution.Infra.CrossCutting.Handlers.Notifications;
using EcoSolution.Infra.Data.Context;
using EcoSolution.Infra.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace EcoSolution.Infra.Data.Repositories
{
    public class MaterialRepository: BaseRepository<Material>, IMaterialRepository
    {

        private readonly IUnitOfWork _uow;
        private readonly INotificationHandler _notificationHandler;

        public MaterialRepository(EcoSolutionContext context,
                                IUnitOfWork uow,
                                INotificationHandler notificationHandler) : base(context)
        {
            _uow = uow;
            _notificationHandler = notificationHandler;
        }

        #region Private Methods
        #endregion

        #region Public Methods

        public async Task<Material> InserirMaterial(Material entity)
        {
            try
            {
                await AddAsync(entity);
                _uow.Commit();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inserir material: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Material?>> BuscarMateriais()
        {
            return await Query().ToListAsync();
        }

        public async Task<Material?> BuscarMaterialId(long materialId)
        {
            return await Query().Where(c => c.Id == materialId).FirstOrDefaultAsync();
        }

        public async Task<Material> AtualizarMaterial(Material entity)
        {
            try
            {
                await UpdateAsync(entity);
                _uow.Commit();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar material: {ex.Message}");
            }
        }
   
        public async Task<bool> ExcluirMaterial(long materialId)
        {
            try
            {
                var material = await BuscarMaterialId(materialId);
                if (material == null)
                {
                    _notificationHandler.AddNotification("Material não encontrado.");
                    return false;
                }

                await RemoveAsync(material);
                _uow.Commit();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao excluir material: {ex.Message}");
            }
        }
   
        #endregion
    }
}

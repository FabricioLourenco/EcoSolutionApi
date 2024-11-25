using EcoSolution.Domain.Entities;
using EcoSolution.Domain.Interface.Infra.Data;
using EcoSolution.Domain.Interface.Infra.Data.Repositories;
using EcoSolution.Infra.CrossCutting.Handlers.Notifications;
using EcoSolution.Infra.Data.Context;
using EcoSolution.Infra.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace EcoSolution.Infra.Data.Repositories
{
    public class ManualRepository : BaseRepository<Manual>, IManualRepository 
    {
        private readonly IUnitOfWork _uow;
        private readonly INotificationHandler _notificationHandler;

        public ManualRepository(EcoSolutionContext context,
                                IUnitOfWork uow,
                                INotificationHandler notificationHandler) : base(context)
        {
            _uow = uow;
            _notificationHandler = notificationHandler;
        }

        #region Private Methods
        #endregion

        #region Public Methods

        public async Task<Manual> InserirManual(Manual entity)
        {
            try
            {
                await AddAsync(entity);
                _uow.Commit();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inserir manual: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Manual>> BuscarManuais()
        {
            return await Query().Include(c => c.ArquivosVinculados).ThenInclude(d => d.Arquivo).ToListAsync();
        }

        public async Task<Manual?> BuscarManualId(long manualId)
        {
            return await Query().Include(c => c.ArquivosVinculados).ThenInclude(d => d.Arquivo).Where(c => c.Id == manualId).FirstOrDefaultAsync();
        }

        public async Task<Manual> AtualizarManual(Manual entity)
        {
            try
            {
                await UpdateAsync(entity);
                _uow.Commit();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar manual: {ex.Message}");
            }
        }

        public async Task<bool> ExcluirManual(long manualId)
        {
            try
            {
                var manual = await BuscarManualId(manualId);
                if (manual == null)
                {
                    _notificationHandler.AddNotification("Manual não encontrado.");
                    return false;
                }

                await RemoveAsync(manual);
                _uow.Commit();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao excluir manual: {ex.Message}");
            }
        }

        #endregion
    }
}

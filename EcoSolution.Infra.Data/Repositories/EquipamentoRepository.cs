using EcoSolution.Domain.Entities;
using EcoSolution.Domain.Interface.Infra.Data;
using EcoSolution.Domain.Interface.Infra.Data.Repositories;
using EcoSolution.Infra.CrossCutting.Handlers.Notifications;
using EcoSolution.Infra.Data.Context;
using EcoSolution.Infra.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace EcoSolution.Infra.Data.Repositories
{
    public class EquipamentoRepository : BaseRepository<Equipamento> , IEquipamentoRepository
    {

        private readonly IUnitOfWork _uow;
        private readonly INotificationHandler _notificationHandler;

        public EquipamentoRepository(EcoSolutionContext context,
                                IUnitOfWork uow,
                                INotificationHandler notificationHandler) : base(context)
        {
            _uow = uow;
            _notificationHandler = notificationHandler;
        }

        #region Private Methods
        #endregion

        #region Public Methods

        public async Task<Equipamento> InserirEquipamento(Equipamento entity)
        {
            try
            {
                await AddAsync(entity);
                _uow.Commit();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inserir equipamento: {ex.Message}");
            }
        }
       
        public async Task<IEnumerable<Equipamento>> BuscarEquipamentos()
        {
            return await Query().Include(c => c.ArquivosVinculados).ThenInclude(d => d.Arquivo).ToListAsync();
        }

        public async Task<Equipamento?> BuscarEquipamentoId(long equipamentoId)
        {
            return await Query().Include(c => c.ArquivosVinculados).ThenInclude(d => d.Arquivo).Where(c => c.Id == equipamentoId).FirstOrDefaultAsync();
        }

        public async Task<Equipamento> AtualizarEquipamento(Equipamento entity)
        {
            try
            {
                await UpdateAsync(entity);
                _uow.Commit();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar equipamento: {ex.Message}");
            }
        }

        public async Task<bool> ExcluirEquipamento(long equipamentoId)
        {
            try
            {
                var equipamento = await BuscarEquipamentoId(equipamentoId);
                if (equipamento == null)
                {
                    _notificationHandler.AddNotification("Equipamento não encontrado.");
                    return false;
                }

                await RemoveAsync(equipamento);
                _uow.Commit();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao excluir equipamento: {ex.Message}");
            }
        }

        #endregion
    }
}

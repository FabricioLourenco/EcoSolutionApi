using EcoSolution.Domain.Entities;
using EcoSolution.Domain.Interface.Infra.Data;
using EcoSolution.Domain.Interface.Infra.Data.Repositories;
using EcoSolution.Infra.CrossCutting.Handlers.Notifications;
using EcoSolution.Infra.Data.Context;
using EcoSolution.Infra.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace EcoSolution.Infra.Data.Repositories
{
    public class TarefaRepository : BaseRepository<Tarefa>, ITarefaRepository
    {
        private readonly IUnitOfWork _uow;
        private readonly INotificationHandler _notificationHandler;

        public TarefaRepository(EcoSolutionContext context,
                                IUnitOfWork uow,
                                INotificationHandler notificationHandler) : base(context)
        {
            _uow = uow;
            _notificationHandler = notificationHandler;
        }
     
        #region Private Methods
        #endregion

        #region Public Methods

        public async Task<Tarefa> InserirTarefa(Tarefa entity)
        {
            try
            {
                await AddAsync(entity);
                _uow.Commit();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inserir tarefa: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Tarefa?>> BuscarTarefas()
        {
            return await Query().ToListAsync();
        }

        public async Task<Tarefa?> BuscarTarefaId(long tarefaId)
        {
            return await Query().Where(c => c.Id == tarefaId).FirstOrDefaultAsync();
        }

        public async Task<Tarefa> AtualizarTarefa(Tarefa entity)
        {
            try
            {
                await UpdateAsync(entity);
                _uow.Commit();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar tarefa: {ex.Message}");
            }
        }
  
        public async Task<bool> ExcluirTarefa(long tarefaId)
        {
            try
            {
                var tarefa = await BuscarTarefaId(tarefaId);
                if (tarefa == null)
                {
                    _notificationHandler.AddNotification("Tarefa não encontrada.");
                    return false;
                }

                await RemoveAsync(tarefa);
                _uow.Commit();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao excluir tarefa: {ex.Message}");
            }
        }

        

        #endregion
    }
}

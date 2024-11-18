using EcoSolution.Domain.Entities;
using EcoSolution.Domain.Entities.Base;
using EcoSolution.Domain.Interface.Infra.Data;
using EcoSolution.Domain.Interface.Infra.Data.Repositories;
using EcoSolution.Infra.CrossCutting.Handlers.Notifications;
using EcoSolution.Infra.Data.Context;
using EcoSolution.Infra.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace EcoSolution.Infra.Data.Repositories
{
    public class ArquivoRepository : BaseRepository<Arquivo>, IArquivoRepository
    {
        private readonly IUnitOfWork _uow;
        private readonly INotificationHandler _notificationHandler;

        public ArquivoRepository(EcoSolutionContext context,
                                IUnitOfWork uow,
                                INotificationHandler notificationHandler) : base(context)
        {
            _uow = uow;
            _notificationHandler = notificationHandler;
        }

        #region Private Methods
        #endregion

        #region Public Methods

        public async Task<Arquivo> InserirArquivo(Arquivo entity)
        {
            try
            {
                await AddAsync(entity);
                _uow.Commit();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inserir arquivo: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Arquivo>> BuscarArquivos()
        {
            return await Query().ToListAsync();
        }

        public async Task<Arquivo?> BuscarArquivoId(long arquivoId)
        {
            return await Query().Where(c => c.Id == arquivoId).FirstOrDefaultAsync();
        }

        public async Task<Arquivo> AtualizarArquivo(Arquivo entity)
        {
            try
            {
                await UpdateAsync(entity);
                _uow.Commit();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar arquivo: {ex.Message}");
            }
        }

        public async Task<bool> ExcluirArquivo(long arquivoId)
        {
            try
            {
                var arquivo = await BuscarArquivoId(arquivoId);
                if (arquivo == null)
                {
                    _notificationHandler.AddNotification("Arquivo não encontrada.");
                    return false;
                }

                await RemoveAsync(arquivo);
                _uow.Commit();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao excluir arquivo: {ex.Message}");
            }
        }

        #endregion

    }
}

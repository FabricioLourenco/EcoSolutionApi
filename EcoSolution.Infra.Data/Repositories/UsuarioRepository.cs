using EcoSolution.Domain.Entities;
using EcoSolution.Domain.Interface.Infra.Data;
using EcoSolution.Domain.Interface.Infra.Data.Repositories;
using EcoSolution.Infra.CrossCutting.Handlers.Notifications;
using EcoSolution.Infra.Data.Context;
using EcoSolution.Infra.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace EcoSolution.Infra.Data.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario> , IUsuarioRepository
    {

        private readonly IUnitOfWork _uow;
        private readonly INotificationHandler _notificationHandler;

        public UsuarioRepository(EcoSolutionContext context,
                                 IUnitOfWork uow,
                                 INotificationHandler notificationHandler) : base(context)
        {
            _uow = uow;
            _notificationHandler = notificationHandler;
        }

        #region Private Methods
        #endregion

        #region Public Methods

        public async Task<Usuario> InserirUsuario(Usuario entity)
        {
            try
            {
                await AddAsync(entity);
                _uow.Commit();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inserir usuario: {ex.Message}");
            }
        }

        public async Task<Usuario> AtualizarUsuario(Usuario entity)
        {
            try
            {
                await UpdateAsync(entity);
                _uow.Commit();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar usuario: {ex.Message}");
            }
        }

        public async Task<Usuario> BuscarUsuario(long estacaoId)
        {
            return await Query().Where(c => c.EstacaoId.Equals(estacaoId)).FirstOrDefaultAsync();
        }

        public async Task<Usuario?> BuscarUsuario(long estacaoId, string chaveSecreta)
        {
            return await Query().Where(c => c.EstacaoId.Equals(estacaoId) &&
                                        c.ChaveSecreta.Equals(chaveSecreta) &&
                                        c.Ativo).FirstOrDefaultAsync();
        }
            
        #endregion
    }
}

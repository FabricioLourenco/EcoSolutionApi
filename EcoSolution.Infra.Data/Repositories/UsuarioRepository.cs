using EcoSolution.Domain.Entities;
using EcoSolution.Domain.Interface.Infra.Data.Repositories;
using EcoSolution.Infra.Data.Context;
using EcoSolution.Infra.Data.Data;

namespace EcoSolution.Infra.Data.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario> , IUsuarioRepository
    {
        public UsuarioRepository(EcoSolutionContext context) : base(context)
        {
            
        }

        #region Private Methods
        #endregion

        #region Public Methods
        #endregion
    }
}

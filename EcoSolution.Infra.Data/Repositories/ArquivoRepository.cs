using EcoSolution.Domain.Entities.Base;
using EcoSolution.Domain.Interface.Infra.Data.Repositories;
using EcoSolution.Infra.Data.Context;
using EcoSolution.Infra.Data.Data;

namespace EcoSolution.Infra.Data.Repositories
{
    public class ArquivoRepository : BaseRepository<Arquivo>, IArquivoRepository
    {
        public ArquivoRepository(EcoSolutionContext context) : base(context)
        {
            
        }

        #region Private Methods
        #endregion

        #region Public Methods
        #endregion

    }
}

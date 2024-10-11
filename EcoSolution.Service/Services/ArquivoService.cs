using AutoMapper;
using EcoSolution.Domain.Interface.Application.Services;
using EcoSolution.Domain.Interface.Infra.Data.Repositories;
using EcoSolution.Infra.CrossCutting.DI;

namespace EcoSolution.Service.Services
{
    public class ArquivoService : IArquivoService, IScopedDependency
    {

        private readonly IMapper _maper;
        private readonly IArquivoRepository _arquivoRepository;

        public ArquivoService(IMapper mapper, IArquivoRepository arquivoRepository)
        {
            _maper = mapper;
            _arquivoRepository = arquivoRepository;
        }

        #region Private Methods
        #endregion

        #region Public Methods
        #endregion
    }
}

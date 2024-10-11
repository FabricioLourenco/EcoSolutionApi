using AutoMapper;
using EcoSolution.Domain.Interface.Application.Services;
using EcoSolution.Domain.Interface.Infra.Data.Repositories;
using EcoSolution.Infra.CrossCutting.DI;

namespace EcoSolution.Service.Services
{
    public class ManualService : IManualService, IScopedDependency
    {

        private readonly IMapper _maper;
        private readonly IManualRepository _manualRepository;

        public ManualService(IMapper mapper, IManualRepository manualRepository)
        {
            _maper = mapper;
            _manualRepository = manualRepository;
        }

        #region Private Methods
        #endregion

        #region Public Methods
        #endregion
    }
}

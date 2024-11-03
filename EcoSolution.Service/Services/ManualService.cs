using AutoMapper;
using EcoSolution.Domain.DTos;
using EcoSolution.Domain.Entities;
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

        public Task<Manual> InserirManual(ManualDTo model)
        {
            throw new NotImplementedException();
        }

        public Task<List<Manual>> BuscarManuais()
        {
            throw new NotImplementedException();
        }

        public Task<Manual> AtualizarManual(ManualDTo model)
        {
            throw new NotImplementedException();
        }
        public Task<bool> ExcluirManual(long manualId)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

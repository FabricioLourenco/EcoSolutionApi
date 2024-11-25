using AutoMapper;
using EcoSolution.Domain.DTos;
using EcoSolution.Domain.DTos.Base;
using EcoSolution.Domain.Entities;
using EcoSolution.Domain.Interface.Application.Services;
using EcoSolution.Domain.Interface.Infra.Data.Repositories;
using EcoSolution.Infra.CrossCutting.DI;

namespace EcoSolution.Service.Services
{
    public class ManualService : IManualService, IScopedDependency
    {

        private readonly IMapper _mapper;
        private readonly IManualRepository _manualRepository;

        public ManualService(IMapper mapper, IManualRepository manualRepository)
        {
            _mapper = mapper;
            _manualRepository = manualRepository;
        }
      
        #region Private Methods
        #endregion

        #region Public Methods

        public async Task<Manual> InserirManual(ManualDTo model)
        {
            var manual = _mapper.Map<Manual>(model);
            return await _manualRepository.InserirManual(manual);
        }

        public async Task<List<Manual>> BuscarManuais()
        {
            return (await _manualRepository.BuscarManuais()).ToList();
        }

        public async Task<Manual> AtualizarManual(UpdateManualDTo model)
        {
            var manual = _mapper.Map<Manual>(model);
            return await _manualRepository.AtualizarManual(manual);
        }
        public async Task<bool> ExcluirManual(long manualId)
        {
            return await _manualRepository.ExcluirManual(manualId);
        }

        #endregion
    }
}

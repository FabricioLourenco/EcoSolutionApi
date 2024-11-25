using AutoMapper;
using EcoSolution.Domain.DTos;
using EcoSolution.Domain.DTos.Base;
using EcoSolution.Domain.Entities;
using EcoSolution.Domain.Interface.Application.Services;
using EcoSolution.Domain.Interface.Infra.Data.Repositories;
using EcoSolution.Infra.CrossCutting.DI;

namespace EcoSolution.Service.Services
{
    public class EquipamentoService : IEquipamentoService, IScopedDependency
    {

        private readonly IMapper _mapper;
        private readonly IEquipamentoRepository _equipamentoRepository;

        public EquipamentoService(IMapper mapper, IEquipamentoRepository equipamentoRepository)
        {
            _mapper = mapper;
            _equipamentoRepository = equipamentoRepository;
        }
      
        #region Private Methods
        #endregion

        #region Public Methods

        public async Task<Equipamento> InserirEquipamento(EquipamentoDTo model)
        {
            var equipamento = _mapper.Map<Equipamento>(model);
            return await _equipamentoRepository.InserirEquipamento(equipamento);
        }

        public async Task<List<Equipamento>> BuscarEquipamentos()
        {
            return (await _equipamentoRepository.BuscarEquipamentos()).ToList();
        }

        public async Task<Equipamento> AtualizarEquipamento(UpdateEquipamentoDTo model)
        {
            var equipamento = _mapper.Map<Equipamento>(model);
            return await _equipamentoRepository.AtualizarEquipamento(equipamento);
        }

        public async Task<bool> ExcluirEquipamento(long equipamentoId)
        {
            return await _equipamentoRepository.ExcluirEquipamento(equipamentoId);
        }

        #endregion
    }
}

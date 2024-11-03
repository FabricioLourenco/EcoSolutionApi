using AutoMapper;
using EcoSolution.Domain.DTos;
using EcoSolution.Domain.Entities;
using EcoSolution.Domain.Interface.Application.Services;
using EcoSolution.Domain.Interface.Infra.Data.Repositories;
using EcoSolution.Infra.CrossCutting.DI;

namespace EcoSolution.Service.Services
{
    public class EquipamentoService : IEquipamentoService, IScopedDependency
    {

        private readonly IMapper _maper;
        private readonly IEquipamentoRepository _equipamentoRepository;

        public EquipamentoService(IMapper mapper, IEquipamentoRepository equipamentoRepository)
        {
            _maper = mapper;
            _equipamentoRepository = equipamentoRepository;
        }
      
        #region Private Methods
        #endregion

        #region Public Methods

        public Task<Equipamento> InserirEquipamento(EquipamentoDTo model)
        {
            throw new NotImplementedException();
        }

        public Task<List<Equipamento>> BuscarEquipamentos()
        {
            throw new NotImplementedException();
        }

        public Task<Equipamento> AtualizarEquipamento(EquipamentoDTo model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExcluirEquipamento(long equipamentoId)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

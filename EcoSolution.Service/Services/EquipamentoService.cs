using AutoMapper;
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
        #endregion
    }
}

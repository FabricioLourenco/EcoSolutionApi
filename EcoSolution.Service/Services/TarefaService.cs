using AutoMapper;
using EcoSolution.Domain.Interface.Application.Services;
using EcoSolution.Domain.Interface.Infra.Data.Repositories;
using EcoSolution.Infra.CrossCutting.DI;

namespace EcoSolution.Service.Services
{
    public class TarefaService : ITarefaService, IScopedDependency
    {

        private readonly IMapper _mapper;
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaService(IMapper mapper, ITarefaRepository tarefaRepository)
        {
            _mapper = mapper;
            _tarefaRepository = tarefaRepository;
        }

        #region Private Methods
        #endregion

        #region Public Methods
        #endregion

    }
}

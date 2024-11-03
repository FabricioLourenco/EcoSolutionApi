using AutoMapper;
using EcoSolution.Domain.DTos;
using EcoSolution.Domain.Entities;
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

        public Task<Tarefa> InserirTarefa(TarefaDTo model)
        {
            throw new NotImplementedException();
        }

        public Task<List<Tarefa>> BuscarTarefas()
        {
            throw new NotImplementedException();
        }

        public Task<Tarefa> AtualizarTarefa(TarefaDTo model)
        {
            throw new NotImplementedException();
        }
      
        public Task<bool> ExcluirTarefa(long tarefaId)
        {
            throw new NotImplementedException();
        }
      
        #endregion
    }
}

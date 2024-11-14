using AutoMapper;
using EcoSolution.Domain.DTos;
using EcoSolution.Domain.DTos.Base;
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
        private readonly IUsuarioRepository _usuarioRepository;

        public TarefaService(IMapper mapper, ITarefaRepository tarefaRepository, IUsuarioRepository usuarioRepository)
        {
            _mapper = mapper;
            _tarefaRepository = tarefaRepository;
            _usuarioRepository = usuarioRepository;

        }

        #region Private Methods
        #endregion

        #region Public Methods

        public async Task<Tarefa> InserirTarefa(TarefaDTo model, string estacaoId)
        {
            var usuario = await _usuarioRepository.BuscarUsuario(long.Parse(estacaoId));
            if (usuario == null)
                throw new Exception($"Usuario pertencente ao estacaoId: '{estacaoId}', não foi encontrado");

            var tarefa = _mapper.Map<Tarefa>(model);
            tarefa.Usuario = usuario;
            tarefa.UsuarioId = usuario.Id;
            return await _tarefaRepository.InserirTarefa(tarefa);
        }

        public async Task<List<Tarefa>> BuscarTarefas()
        {
            return (await _tarefaRepository.BuscarTarefas()).ToList();
        }

        public async Task<Tarefa> AtualizarTarefa(UpdateTarefaDTo model, string estacaoId)
        {
            var usuario = await _usuarioRepository.BuscarUsuario(long.Parse(estacaoId));
            if (usuario == null)
                throw new Exception($"Usuario pertencente ao estacaoId: '{estacaoId}', não foi encontrado");

            var tarefa = _mapper.Map<Tarefa>(model);
            tarefa.Usuario = usuario;
            tarefa.UsuarioId = usuario.Id;
            return await _tarefaRepository.AtualizarTarefa(tarefa);
        }
      
        public async Task<bool> ExcluirTarefa(long tarefaId)
        {
            return await _tarefaRepository.ExcluirTarefa(tarefaId);
        }
      
        #endregion
    }
}

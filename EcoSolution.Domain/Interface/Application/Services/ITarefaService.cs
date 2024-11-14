using EcoSolution.Domain.DTos;
using EcoSolution.Domain.DTos.Base;
using EcoSolution.Domain.Entities;

namespace EcoSolution.Domain.Interface.Application.Services
{
    public interface ITarefaService
    {
        Task<Tarefa> InserirTarefa(TarefaDTo model, string estacaoId);

        Task<List<Tarefa>> BuscarTarefas();

        Task<Tarefa> AtualizarTarefa(UpdateTarefaDTo model, string estacaoId);

        Task<bool> ExcluirTarefa (long tarefaId);
    }
}

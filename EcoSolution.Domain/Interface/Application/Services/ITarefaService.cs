using EcoSolution.Domain.DTos;
using EcoSolution.Domain.Entities;

namespace EcoSolution.Domain.Interface.Application.Services
{
    public interface ITarefaService
    {
        Task<Tarefa> InserirTarefa(TarefaDTo model);

        Task<List<Tarefa>> BuscarTarefas();

        Task<Tarefa> AtualizarTarefa(TarefaDTo model);

        Task<bool> ExcluirTarefa (long tarefaId);
    }
}

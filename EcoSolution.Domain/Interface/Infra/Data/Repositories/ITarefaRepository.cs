using EcoSolution.Domain.Entities;

namespace EcoSolution.Domain.Interface.Infra.Data.Repositories
{
    public interface ITarefaRepository
    {
        Task<Tarefa> InserirTarefa(Tarefa entity);

        Task<IEnumerable<Tarefa>> BuscarTarefas();

        Task<Tarefa?> BuscarTarefaId(long tarefaId);

        Task<Tarefa> AtualizarTarefa(Tarefa entity);

        Task<bool> ExcluirTarefa(long tarefaId);
    }
}

using EcoSolution.Domain.Entities;
using EcoSolution.Domain.Entities.Base;

namespace EcoSolution.Domain.Interface.Infra.Data.Repositories
{
    public interface IArquivoRepository
    {
        Task<Arquivo> InserirArquivo(Arquivo entity);

        Task<IEnumerable<Arquivo>> BuscarArquivos();

        Task<Arquivo?> BuscarArquivoId(long arquivoId);

        Task<Arquivo> AtualizarArquivo(Arquivo entity);

        Task<bool> ExcluirArquivo(long arquivoId);
    }
}

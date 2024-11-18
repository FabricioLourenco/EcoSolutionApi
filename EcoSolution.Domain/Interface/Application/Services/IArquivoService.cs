using EcoSolution.Domain.DTos.Base;
using EcoSolution.Domain.Entities.Base;

namespace EcoSolution.Domain.Interface.Application.Services
{
    public interface IArquivoService
    {
        Task<Arquivo> InserirArquivo(ArquivoDTo model);

        Task<List<Arquivo>> BuscarArquivos();

        Task<Arquivo> AtualizarArquivo(UpdateArquivoDTo model);

        Task<bool> ExcluirArquivo(long arquivoId);
    }
}

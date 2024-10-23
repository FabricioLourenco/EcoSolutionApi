using EcoSolution.Domain.Entities;

namespace EcoSolution.Domain.Interface.Infra.Data.Repositories
{
    public interface IUsuarioRepository : IAsyncRepository<Usuario>
    {
        Task<Usuario> InserirUsuario(Usuario entity);

        Task<Usuario?> BuscarUsuario(long estacaoId, string chaveSecreta);

        Task<Usuario> BuscarUsuario(long estacaoId);

        Task<Usuario> AtualizarUsuario(Usuario entity);

    }
}

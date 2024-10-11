using EcoSolution.Domain.DTos;
using EcoSolution.Domain.Entities;

namespace EcoSolution.Domain.Interface.Application.Services
{
    public interface IUsuarioService
    {
        Task<Usuario> InserirUsuario(UsuarioDTo model);

        Task<Usuario?> BuscarUsuario(long estacaoId, string chaveSecreta);

        Task<Usuario> BuscarUsuario(long estacaoId);

        Task<bool> AlterarStatusUsuario(bool status, long estacaoId);
    }
}

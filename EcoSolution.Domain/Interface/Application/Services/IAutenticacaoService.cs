using EcoSolution.Domain.DTos.Base;

namespace EcoSolution.Domain.Interface.Application.Services
{
    public interface IAutenticacaoService
    {
        Task<TokenDTo> GetToken(LoginDTo login);
    }
}

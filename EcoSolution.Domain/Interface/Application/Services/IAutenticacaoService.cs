using EcoSolution.Domain.DTos.Base;

namespace EcoSolution.Domain.Interface.Application.Services
{
    public interface IAutenticacaoService
    {

        bool ExisteChaveDeAcesso(string chaveAcesso);

        bool ValidarChave(LoginDTo login);

        TokenDTo GetToken(LoginDTo login);
    }
}

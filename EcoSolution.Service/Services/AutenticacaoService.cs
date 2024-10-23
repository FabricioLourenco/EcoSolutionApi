using EcoSolution.Domain.DTos.Base;
using EcoSolution.Domain.Enuns;
using EcoSolution.Domain.Interface.Application.Services;
using EcoSolution.Domain.Interface.Infra.Data.Repositories;
using EcoSolution.Infra.CrossCutting.DI;
using EcoSolution.Infra.CrossCutting.Handlers.Jwt;
using EcoSolution.Infra.CrossCutting.Handlers.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace EcoSolution.Service.Services
{
    public class AutenticacaoService : IAutenticacaoService, IScopedDependency
    {

        private readonly IJwtHandler _jwtHandler;
        private readonly IConfiguration _configuration;
        private readonly INotificationHandler _notificationHandler;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AutenticacaoService(IJwtHandler jwtHandler, 
                                   IConfiguration configuration,
                                   INotificationHandler notificationHandler,
                                   IUsuarioRepository usuarioRepository,
                                   IHttpContextAccessor httpContextAccessor)
        {
            _jwtHandler = jwtHandler;
            _configuration = configuration;
            _notificationHandler = notificationHandler;
            _usuarioRepository = usuarioRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        #region Private Methods

        private TokenDTo Token(LoginDTo login, long usuarioId, string nome, FuncaoEnum funcao)
        {
            var jwtResponse = _jwtHandler.GetToken(new JwtHandlerOptions()
            {
                EstacaoId = login.EstacaoId,
                UsuarioId = usuarioId,
                Nome = nome,
                Funcao = funcao.ToString(),
                ExpireIn = DateTime.UtcNow.AddSeconds(Convert.ToInt32(_configuration.GetSection("JwtHandler:ExpireInSeconds").Value)).ToLocalTime(),
                JwtPrivateKey = _configuration.GetSection("JwtHandler:PrivateKey").Value
            }, FuncaoEnum.Operador.ToString());

            return new TokenDTo()
            {
                BearerToken = jwtResponse.Token,
                ExpiresIn = jwtResponse.ExpireIn
            };
        }

        #endregion

        #region Public Methods

        public async Task<TokenDTo> GetToken(LoginDTo login)
        {
            var usuario = await _usuarioRepository.BuscarUsuario(login.EstacaoId, login.ChaveSecreta);
            if (usuario == null)
                throw new Exception($"Não foi localizado o cadastro da estacao {login.EstacaoId} ou a mesma encontra-se inativa.");
            return Token(login, usuario.Id, usuario.Nome, usuario.Funcao);
        }



        #endregion
    }
}

using Asp.Versioning;
using EcoSolution.Domain.DTos.Base;
using EcoSolution.Domain.Interface.Application.Services;
using EcoSolution.Infra.CrossCutting.Handlers.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoSolutionApi.Controllers.V1
{

    [ApiController]
    [ApiVersion(1.0)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AutenticacaoController : QControllerBase
    {
        private readonly INotificationHandler _notificationHandler;
        private readonly IAutenticacaoService _autenticacaoService;

        public AutenticacaoController(IAutenticacaoService autenticacaoService, INotificationHandler notificationHandler)
        {
            _notificationHandler = notificationHandler;
            _autenticacaoService = autenticacaoService;
        }

        [HttpPost]
        [Route("token")]
        [AllowAnonymous]
        public IActionResult Login(LoginDTo login)
        {
            var validaChave = _autenticacaoService.ValidarChave(login);
            if (validaChave)
                return QResult(_autenticacaoService.GetToken(login));

            _notificationHandler.AddNotification("Dados Inválidos.");
            return QResult(null);
        }
    }
}

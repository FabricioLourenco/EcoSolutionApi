using Asp.Versioning;
using EcoSolution.Domain.DTos.Base;
using EcoSolution.Domain.Interface.Application.Services;
using EcoSolution.Infra.CrossCutting.Handlers.Notifications;
using EcoSolutionApi.Filters;
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
        [TypeFilter(typeof(ApiKeyAttribute))]
        public async Task<IActionResult> Login(LoginDTo login)
        {
            return QResult(await _autenticacaoService.GetToken(login));
        }
    }
}

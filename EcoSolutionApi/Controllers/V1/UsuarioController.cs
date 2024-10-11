using Asp.Versioning;
using EcoSolution.Domain.DTos;
using EcoSolution.Domain.DTos.Base;
using EcoSolution.Domain.Interface.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcoSolutionApi.Controllers.V1
{

    [ApiController]
    [ApiVersion(1.0)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UsuarioController : QControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [MapToApiVersion(1.0)]
        [Route("inserir-usuario")]
        public async Task<IActionResult> InserirUsuario([FromBody] UsuarioDTo model)
        {
            var usuario = await _usuarioService.InserirUsuario(model);
            return QResult(usuario);
        }

        [HttpPut]
        [MapToApiVersion(1.0)]
        [Route("alterar-status-usuario")]
        public async Task<IActionResult> AlterarStatusUsuario([FromBody] StatusUsuarioDTo model)
        {
            var status = await _usuarioService.AlterarStatusUsuario(model.Usuario, model.EstacaoId);
            return QResult();
        }

    }
}

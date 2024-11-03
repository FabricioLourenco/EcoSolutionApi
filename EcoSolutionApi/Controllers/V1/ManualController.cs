using Asp.Versioning;
using EcoSolution.Domain.DTos;
using EcoSolution.Domain.Interface.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoSolutionApi.Controllers.V1
{
    [ApiController]
    [ApiVersion(1.0)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ManualController : QControllerBase
    {

        private readonly IManualService _manualService;

        public ManualController(IManualService manualService)
        {
            _manualService = manualService;
        }

        [HttpPost]
        [MapToApiVersion(1.0)]
        [Authorize]
        [Route("inserir-manual")]
        public async Task<IActionResult> InserirManual([FromBody] ManualDTo model)
        {
            var manual = await _manualService.InserirManual(model);
            return QResult(manual);
        }

        [HttpGet]
        [MapToApiVersion(1.0)]
        [Authorize]
        [Route("buscar-manuais")]
        public async Task<IActionResult> BuscarManuais()
        {
            var manuais = await _manualService.BuscarManuais();
            return QResult(manuais);
        }

        [HttpPut]
        [MapToApiVersion(1.0)]
        [Authorize]
        [Route("editar-manual")]
        public async Task<IActionResult> AtualizarManual([FromBody] ManualDTo model)
        {
            var manual = await _manualService.AtualizarManual(model);
            return QResult(manual);
        }

        [HttpDelete]
        [MapToApiVersion(1.0)]
        [Authorize]
        [Route("excluir-manual")]
        public async Task<IActionResult> ExcluirManual([FromBody] long manualId)
        {
            var manual = await _manualService.ExcluirManual(manualId);
            return QResult(manual);
        }

    }
}

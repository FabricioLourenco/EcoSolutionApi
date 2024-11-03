using Asp.Versioning;
using EcoSolution.Domain.DTos;
using EcoSolution.Domain.Interface.Application.Services;
using EcoSolution.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoSolutionApi.Controllers.V1
{
    [ApiController]
    [ApiVersion(1.0)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class MaterialController : QControllerBase
    {

        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpPost]
        [MapToApiVersion(1.0)]
        [Authorize]
        [Route("inserir-material")]
        public async Task<IActionResult> InserirMaterial([FromBody] MaterialDTo model)
        {
            var material = await _materialService.InserirMaterial(model);
            return QResult(material);
        }

        [HttpGet]
        [MapToApiVersion(1.0)]
        [Authorize]
        [Route("buscar-materiais")]
        public async Task<IActionResult> BuscarMateriais()
        {
            var materiais = await _materialService.BuscarMateriais();
            return QResult(materiais);
        }

        [HttpPut]
        [MapToApiVersion(1.0)]
        [Authorize]
        [Route("editar-material")]
        public async Task<IActionResult> AtualizarMaterial([FromBody] MaterialDTo model)
        {
            var material = await _materialService.AtualizarMaterial(model);
            return QResult(material);
        }

        [HttpDelete]
        [MapToApiVersion(1.0)]
        [Authorize]
        [Route("excluir-material")]
        public async Task<IActionResult> ExcluirMaterial([FromBody] long tarefaId)
        {
            var material = await _materialService.ExcluirMaterial(tarefaId);
            return QResult(material);
        }


    }
}

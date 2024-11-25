using Asp.Versioning;
using EcoSolution.Domain.DTos;
using EcoSolution.Domain.DTos.Base;
using EcoSolution.Domain.Interface.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoSolutionApi.Controllers.V1
{
    [ApiController]
    [ApiVersion(1.0)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class EquipamentoController : QControllerBase
    {
        private readonly IEquipamentoService _equipamentoService;

        public EquipamentoController(IEquipamentoService equipamentoService)
        {
            _equipamentoService = equipamentoService;
        }

        [HttpPost]
        [MapToApiVersion(1.0)]
        [Authorize]
        [Route("inserir-equipamento")]
        public async Task<IActionResult> InserirEquipamento([FromBody] EquipamentoDTo model)
        {
            var equipamento = await _equipamentoService.InserirEquipamento(model);
            return QResult(equipamento);
        }

        [HttpGet]
        [MapToApiVersion(1.0)]
        [Authorize]
        [Route("buscar-equipamentos")]
        public async Task<IActionResult> BuscarEquipamentos()
        {
            var equipamentos = await _equipamentoService.BuscarEquipamentos();
            return QResult(equipamentos);
        }

        [HttpPut]
        [MapToApiVersion(1.0)]
        [Authorize]
        [Route("editar-equipamento")]
        public async Task<IActionResult> AtualizarEquipamento([FromBody] UpdateEquipamentoDTo model)
        {
            var equipamento = await _equipamentoService.AtualizarEquipamento(model);
            return QResult(equipamento);
        }

        [HttpDelete]
        [MapToApiVersion(1.0)]
        [Authorize]
        [Route("excluir-equipamento")]
        public async Task<IActionResult> ExcluirEquipamento([FromBody] RemoverDTo model)
        {
            var equipamento = await _equipamentoService.ExcluirEquipamento(model.Id);
            return QResult(equipamento);
        }

    }
}

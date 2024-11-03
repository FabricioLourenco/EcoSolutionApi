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
    public class TarefaController : QControllerBase
    {
        private readonly ITarefaService _tarefaService;

        public TarefaController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        [HttpPost]
        [MapToApiVersion(1.0)]
        [Authorize]
        [Route("inserir-tarefa")]
        public async Task<IActionResult> InserirTarefa([FromBody] TarefaDTo model)
        {
            var tarefa = await _tarefaService.InserirTarefa(model);
            return QResult(tarefa);
        }

        [HttpGet]
        [MapToApiVersion(1.0)]
        [Authorize]
        [Route("buscar-tarefas")]
        public async Task<IActionResult> BuscarTarefas()
        {
            var tarefas = await _tarefaService.BuscarTarefas();
            return QResult(tarefas);
        }

        [HttpPut]
        [MapToApiVersion(1.0)]
        [Authorize]
        [Route("editar-tarefa")]
        public async Task<IActionResult> AtualizarTarefa([FromBody] TarefaDTo model)
        {
            var tarefa = await _tarefaService.AtualizarTarefa(model);
            return QResult(tarefa);
        }

        [HttpDelete]
        [MapToApiVersion(1.0)]
        [Authorize]
        [Route("excluir-tarefa")]
        public async Task<IActionResult> ExcluirTarefa([FromBody] long tarefaId)
        {
            var tarefa = await _tarefaService.ExcluirTarefa(tarefaId);
            return QResult(tarefa);
        }

    }
}

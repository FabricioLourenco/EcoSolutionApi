using Asp.Versioning;
using EcoSolution.Domain.DTos.Base;
using EcoSolution.Domain.Interface.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoSolutionApi.Controllers.V1
{
    [ApiController]
    [ApiVersion(1.0)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ArquivoController : QControllerBase
    {

        private readonly IArquivoService _arquivoService;

        public ArquivoController(IArquivoService arquivoService)
        {
            _arquivoService = arquivoService;
        }

        [HttpPost]
        [MapToApiVersion(1.0)]
        [Authorize]
        [Route("inserir-arquivo")]
        public async Task<IActionResult> InserirArquivo([FromBody] ArquivoDTo model)
        {
            var arquivo = await _arquivoService.InserirArquivo(model);
            return QResult(arquivo);
        }

        [HttpGet]
        [MapToApiVersion(1.0)]
        [Authorize]
        [Route("buscar-arquivos")]
        public async Task<IActionResult> BuscarArquivos()
        {
            var arquivos = await _arquivoService.BuscarArquivos();
            return QResult(arquivos);
        }

        [HttpPut]
        [MapToApiVersion(1.0)]
        [Authorize]
        [Route("editar-arquivo")]
        public async Task<IActionResult> AtualizarArquivo([FromBody] UpdateArquivoDTo model)
        {
            var arquivo = await _arquivoService.AtualizarArquivo(model);
            return QResult(arquivo);
        }

        [HttpDelete]
        [MapToApiVersion(1.0)]
        [Authorize]
        [Route("excluir-arquivo")]
        public async Task<IActionResult> ExcluirArquivo([FromBody] RemoverDTo model)
        {
            var arquivo = await _arquivoService.ExcluirArquivo(model.Id);
            return QResult(arquivo);
        }

    }
}

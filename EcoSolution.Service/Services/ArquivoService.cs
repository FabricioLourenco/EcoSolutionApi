using AutoMapper;
using EcoSolution.Domain.DTos.Base;
using EcoSolution.Domain.Entities.Base;
using EcoSolution.Domain.Interface.Application.Services;
using EcoSolution.Domain.Interface.Infra.Data.Repositories;
using EcoSolution.Infra.CrossCutting.DI;

namespace EcoSolution.Service.Services
{
    public class ArquivoService : IArquivoService, IScopedDependency
    {

        private readonly IMapper _mapper;
        private readonly IArquivoRepository _arquivoRepository;

        public ArquivoService(IMapper mapper, IArquivoRepository arquivoRepository)
        {
            _mapper = mapper;
            _arquivoRepository = arquivoRepository;
        }
      
        #region Private Methods
        #endregion

        #region Public Methods

        public async Task<Arquivo> InserirArquivo(ArquivoDTo model)
        {
            var arquivo = _mapper.Map<Arquivo>(model);
            return await _arquivoRepository.InserirArquivo(arquivo);
        }

        public async Task<List<Arquivo>> BuscarArquivos()
        {
            return (await _arquivoRepository.BuscarArquivos()).ToList();
        }

        public async Task<Arquivo> AtualizarArquivo(UpdateArquivoDTo model)
        {
            var arquivo = _mapper.Map<Arquivo>(model);
            return await _arquivoRepository.AtualizarArquivo(arquivo);
        }
        public async Task<bool> ExcluirArquivo(long arquivoId)
        {
            return await _arquivoRepository.ExcluirArquivo(arquivoId);
        }

        #endregion
    }
}

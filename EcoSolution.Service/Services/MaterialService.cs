using AutoMapper;
using EcoSolution.Domain.DTos;
using EcoSolution.Domain.DTos.Base;
using EcoSolution.Domain.Entities;
using EcoSolution.Domain.Interface.Application.Services;
using EcoSolution.Domain.Interface.Infra.Data.Repositories;
using EcoSolution.Infra.CrossCutting.DI;

namespace EcoSolution.Service.Services
{
    public class MaterialService : IMaterialService , IScopedDependency
    {

        private readonly IMapper _mapper;
        private readonly IMaterialRepository _materialRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public MaterialService(IMapper mapper, IMaterialRepository materialRepository, IUsuarioRepository usuarioRepository)
        {
            _mapper = mapper;
            _materialRepository = materialRepository;
            _usuarioRepository = usuarioRepository;
        }

        #region Private Methods
        #endregion

        #region Public Methods
     
        public async Task<Material> InserirMaterial(MaterialDTo model)
        {
            var material = _mapper.Map<Material>(model);
            return await _materialRepository.InserirMaterial(material);
        }

        public async Task<List<Material>> BuscarMateriais()
        {
            return (await _materialRepository.BuscarMateriais()).ToList();
        }

        public async Task<Material> AtualizarMaterial(UpdateMaterialDTo model)
        {
            var material = _mapper.Map<Material>(model);
            return await _materialRepository.AtualizarMaterial(material);
        }

        public async Task<bool> ExcluirMaterial(long materialId)
        {
            return await _materialRepository.ExcluirMaterial(materialId);
        }

        #endregion
    }
}

using AutoMapper;
using EcoSolution.Domain.DTos;
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

        public MaterialService(IMapper mapper, IMaterialRepository materialRepository)
        {
            _mapper = mapper;
            _materialRepository = materialRepository;
        }

        #region Private Methods
        #endregion

        #region Public Methods
     
        public Task<Material> InserirMaterial(MaterialDTo model)
        {
            throw new NotImplementedException();
        }

        public Task<List<Material>> BuscarMateriais()
        {
            throw new NotImplementedException();
        }

        public Task<Material> AtualizarMaterial(MaterialDTo model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExcluirMaterial(long materialId)
        {
            throw new NotImplementedException();
        }
      
        #endregion
    }
}

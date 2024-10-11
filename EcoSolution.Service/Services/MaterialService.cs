using AutoMapper;
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
        #endregion
    }
}

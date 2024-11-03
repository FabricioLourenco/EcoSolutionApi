using AutoMapper;
using EcoSolution.Domain.DTos.Base;
using EcoSolution.Domain.Entities.Base;

namespace EcoSolution.Service.Mappers
{
    public class ArquivoVinculadoMapper : Profile
    {
        public ArquivoVinculadoMapper()
        {
            CreateMap<ArquivoVinculadoDTo, ArquivoVinculado>().ReverseMap();
        }
    }
}

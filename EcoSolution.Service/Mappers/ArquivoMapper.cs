using AutoMapper;
using EcoSolution.Domain.DTos.Base;
using EcoSolution.Domain.Entities.Base;

namespace EcoSolution.Service.Mappers
{
    public class ArquivoMapper : Profile
    {
        public ArquivoMapper()
        {
            CreateMap<ArquivoDTo, Arquivo>().ReverseMap();
            CreateMap<UpdateArquivoDTo, Arquivo>().ReverseMap();
        }
    }
}

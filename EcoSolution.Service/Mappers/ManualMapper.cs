using AutoMapper;
using EcoSolution.Domain.DTos;
using EcoSolution.Domain.DTos.Base;
using EcoSolution.Domain.Entities;

namespace EcoSolution.Service.Mappers
{
    public class ManualMapper : Profile
    {
        public ManualMapper()
        {
            CreateMap<ManualDTo, Manual>().ReverseMap();
            CreateMap<UpdateManualDTo, Manual>().ReverseMap();
        }
    }    
}

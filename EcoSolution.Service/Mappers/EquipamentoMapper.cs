using AutoMapper;
using EcoSolution.Domain.DTos;
using EcoSolution.Domain.DTos.Base;
using EcoSolution.Domain.Entities;

namespace EcoSolution.Service.Mappers
{
    public class EquipamentoMapper : Profile
    {
        public EquipamentoMapper()
        {
            CreateMap<EquipamentoDTo, Equipamento>().ReverseMap();
            CreateMap<UpdateEquipamentoDTo, Equipamento>().ReverseMap();
        }
    }
}

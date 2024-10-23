using AutoMapper;
using EcoSolution.Domain.DTos;
using EcoSolution.Domain.Entities;
using EcoSolution.Infra.CrossCutting.Helpers;

namespace EcoSolution.Service.Mappers
{
    public class UsuarioMapper : Profile
    {
        public UsuarioMapper()
        {
            CreateMap<UsuarioDTo, Usuario>()
                .ForMember(dest => dest.ChaveSecreta, opt => opt.MapFrom(src => StringHelper.Hash($"K$mi@_Ec0_Solution" + src.EstacaoId.ToString())))
                .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => true));
        }
    }
}

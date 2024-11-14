using AutoMapper;
using EcoSolution.Domain.DTos;
using EcoSolution.Domain.DTos.Base;
using EcoSolution.Domain.Entities;

namespace EcoSolution.Service.Mappers
{
    public class TarefaMapper : Profile
    {
        public TarefaMapper()
        {
            CreateMap<TarefaDTo, Tarefa>().ReverseMap();
            CreateMap<UpdateTarefaDTo, Tarefa>().ReverseMap();
        }
    }
}

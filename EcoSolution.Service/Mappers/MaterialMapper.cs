﻿using AutoMapper;
using EcoSolution.Domain.DTos;
using EcoSolution.Domain.Entities;

namespace EcoSolution.Service.Mappers
{
    public class MaterialMapper : Profile
    {
        public MaterialMapper()
        {
            CreateMap<MaterialDTo, Material>().ReverseMap();
        }
    }
}

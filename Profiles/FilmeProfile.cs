using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.models;

namespace FilmesAPI.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<Filme, ReadFilmeDto>();
            CreateMap<UpdateFilmeDto, Filme>(); 
            //CreateMap<ProcessoEmail, Processoview>().ForMember(dest => dest.Id,opt.MapFrom(src.Id))
            //.ForMember(dest => dest.RotinasPropriedades, opt => opt.Ignore());
        }
    }
}

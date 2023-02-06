using AutoMapper;
using EmprestimosLivros.API.DTOs;
using EmprestimosLivros.API.Models;

namespace EmprestimosLivros.API.Mappings
{
    public class EntitesToDTOMappingProfile : Profile
    {
        public EntitesToDTOMappingProfile()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
        }
    }
}

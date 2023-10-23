using AutoMapper;
using EFCore.DTO;
using EFCore.Models;

namespace EFCore.AutoMapper;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<UsuarioDTO, Usuario>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<Usuario, UsuarioDTO>();
    }
}
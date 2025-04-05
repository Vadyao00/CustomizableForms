using AutoMapper;
using CustomizableForms.Domain.DTOs;
using CustomizableForms.Domain.Entities;

namespace CustomizableForms.API;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserForRegistrationDto, User>();
        CreateMap<UserForAuthenticationDto, User>();
        CreateMap<User, UserDto>();
    }
}
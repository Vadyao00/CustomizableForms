using AutoMapper;
using CustomizableForms.Domain.DTOs;
using CustomizableForms.Domain.Entities;

namespace CustomizableForms.API;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // User mappings
        CreateMap<UserForRegistrationDto, User>();
        CreateMap<UserForAuthenticationDto, User>();
        CreateMap<User, UserDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
        
        // Template mappings
        CreateMap<Template, TemplateDto>()
            .ForMember(dest => dest.Tags, opt => opt.Ignore())
            .ForMember(dest => dest.LikesCount, opt => opt.Ignore())
            .ForMember(dest => dest.CommentsCount, opt => opt.Ignore())
            .ForMember(dest => dest.FormsCount, opt => opt.Ignore());
        
        // Question mappings
        CreateMap<Question, QuestionDto>();
        
        // Form mappings
        CreateMap<Form, FormDto>();
        
        // Answer mappings
        CreateMap<Answer, AnswerDto>();
        
        // Comment mappings
        CreateMap<TemplateComment, CommentDto>();
        
        // Tag mappings
        CreateMap<Tag, TagDto>()
            .ForMember(dest => dest.TemplatesCount, opt => opt.Ignore());
    }
}
using AutoMapper;
using CustomizableForms.Domain.DTOs;
using CustomizableForms.Domain.Entities;

namespace CustomizableForms.API;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //User
        CreateMap<UserForRegistrationDto, User>();
        CreateMap<UserForAuthenticationDto, User>();
        CreateMap<User, UserDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.IsActive ? "Active" : "Blocked"));
        
        //Template
        CreateMap<Template, TemplateDto>()
            .ForMember(dest => dest.Tags, opt => opt.Ignore())
            .ForMember(dest => dest.LikesCount, opt => opt.Ignore())
            .ForMember(dest => dest.CommentsCount, opt => opt.Ignore())
            .ForMember(dest => dest.FormsCount, opt => opt.Ignore());
        
        //Question
        CreateMap<Question, QuestionDto>();
        
        //Form
        CreateMap<Form, FormDto>();
        
        //Answer
        CreateMap<Answer, AnswerDto>();
        
        //Comment
        CreateMap<TemplateComment, CommentDto>();
        
        //Tag
        CreateMap<Tag, TagDto>()
            .ForMember(dest => dest.TemplatesCount, opt => opt.Ignore());
    }
}
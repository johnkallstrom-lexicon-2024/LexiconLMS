using AutoMapper;
using LexiconLMS.Core.Entities;
using LexiconLMS.Core.Identity;

namespace LexiconLMS.Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            // Document
            CreateMap<Document, DocumentModel>();
        }
    }
}

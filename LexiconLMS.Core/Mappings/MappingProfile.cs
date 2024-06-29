using LexiconLMS.Core.Models.Activity;
using LexiconLMS.Core.Models.Course;
using LexiconLMS.Core.Models.Document;
using LexiconLMS.Core.Models.Module;
using LexiconLMS.Core.Models.User;

namespace LexiconLMS.Core.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Activity
            CreateMap<Activity, ActivityModel>();
            CreateMap<Activity, ActivityTrimModel>();
            CreateMap<ActivityCreateModel, Activity>();
            CreateMap<ActivityUpdateModel, Activity>();

            // Course
            CreateMap<Course, CourseModel>();
            CreateMap<Course, CourseTrimModel>();
            CreateMap<CourseCreateModel, Course>();
            CreateMap<CourseUpdateModel, Course>();

            // Document
            CreateMap<Document, DocumentModel>().ForMember(dest => dest.UploadedAt, opt => opt.MapFrom(src => src.UploadTime));
            CreateMap<Document, DocumentTrimModel>()
                .ForMember(dest => dest.UploadedAt, opt => opt.MapFrom(src => src.UploadTime))
                .ForMember(dest => dest.UploadedBy, opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"));
            CreateMap<DocumentCreateModel, Document>();
            CreateMap<DocumentUpdateModel, Document>();

            // Module
            CreateMap<Module, ModuleModel>();
            CreateMap<Module, ModuleTrimModel>();
            CreateMap<ModuleCreateModel, Module>();
            CreateMap<ModuleUpdateModel, Module>();

            // User
            CreateMap<User, UserModel>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
            CreateMap<User, UserTrimModel>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
            CreateMap<UserCreateModel, User>();
            CreateMap<UserUpdateModel, User>();

        }
    }
}

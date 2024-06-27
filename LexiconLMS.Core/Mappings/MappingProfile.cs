namespace LexiconLMS.Core.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User
            CreateMap<User, UserModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            CreateMap<UserCreateModel, User>();
            CreateMap<UserUpdateModel, User>();

            // Course
            CreateMap<Course, CourseModel>();

            // Module
            CreateMap<Module, ModuleModel>();
        }
    }
}

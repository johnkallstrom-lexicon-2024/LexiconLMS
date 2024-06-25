using System.Reflection;

namespace LexiconLMS.Api
{
    public static class RegisterServices
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IActivityService, ActivityService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IModuleService, ModuleService>();
            services.AddScoped(typeof(IService<>), typeof(ApiService<>));

            return services;
        }
    }
}

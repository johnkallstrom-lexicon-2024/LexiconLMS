using LexiconLMS.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LexiconLMS.Core
{
    public static class RegisterServices
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IActivityService, ActivityService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IModuleService, ModuleService>();

            return services;
        }
    }
}

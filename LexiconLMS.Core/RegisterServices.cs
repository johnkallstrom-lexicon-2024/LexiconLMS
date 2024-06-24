using LexiconLMS.Core.Interfaces;
using LexiconLMS.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LexiconLMS.Core
{
    public static class RegisterServices
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}

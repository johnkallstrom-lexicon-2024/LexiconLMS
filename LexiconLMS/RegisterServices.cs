namespace LexiconLMS
{
    public static class RegisterServices
    {
        public static IServiceCollection AddHttpServices(this IServiceCollection services)
        {
            services.AddHttpClient<IHttpService, HttpService>(config =>
            {
                config.BaseAddress = new Uri("https://localhost:7104");
            });

            return services;
        }
    }
}

namespace LexiconLMS.Api.Authorization
{
    public class JwtMiddleware
    {
        private readonly IJwtProvider _jwtProvider;
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next, IJwtProvider jwtProvider)
        {
            _next = next;
            _jwtProvider = jwtProvider;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string? token = context.Request.Headers.Authorization.ToString().Split(" ").Last();
            if (!string.IsNullOrWhiteSpace(token))
            {
                // Validate token
            }

            await _next.Invoke(context);
        }
    }

    public static class JwtMiddlewareExtensions
    {
        public static void UseJwtMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<JwtMiddleware>();
        }
    }
}

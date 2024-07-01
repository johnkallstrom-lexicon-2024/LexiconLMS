using LexiconLMS.Core.Models.User;

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

        public async Task InvokeAsync(HttpContext context, IUserService userService)
        {
            string? token = context.Request.Headers.Authorization.ToString().Split(" ").Last();
            if (!string.IsNullOrWhiteSpace(token))
            {
                var result = await _jwtProvider.ValidateTokenAsync(token);
                if (result.Success)
                {
                    int userId = result.Value;
                    var user = await userService.GetUserByIdAsync(userId);

                    context.Items.Add("User", new UserTrimModel
                    {
                        Id = user.Id,
                        Name = $"{user.FirstName} {user.LastName}",
                        Email = user.Email,
                        UserName = user.UserName,
                        Roles = await userService.GetUserRolesAsync(user)
                    });
                }
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

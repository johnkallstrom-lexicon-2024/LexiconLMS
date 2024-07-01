using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace LexiconLMS.Authentication
{
    public class TokenAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;

        public TokenAuthenticationStateProvider(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            ClaimsPrincipal? user = default!;

            string? token = await _localStorage.GetItemAsStringAsync("token");
            if (!string.IsNullOrWhiteSpace(token))
            {
                user = ParseJwtTokenToClaimsPrincipal(token);
            }

            return new AuthenticationState(user);
        }

        private ClaimsPrincipal ParseJwtTokenToClaimsPrincipal(string token)
        {
            JwtSecurityToken? securityToken = default!;

            var handler = new JwtSecurityTokenHandler();
            if (handler.CanReadToken(token))
            {
                securityToken = handler.ReadJwtToken(token);
                var identity = new ClaimsIdentity(securityToken.Claims, authenticationType: "jwt");
                var principal = new ClaimsPrincipal(identity);

                return principal;
            }

            return new ClaimsPrincipal();
        }
    }
}

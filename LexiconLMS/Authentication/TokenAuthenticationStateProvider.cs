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
            string? token = await _localStorage.GetItemAsStringAsync("token");
            if (string.IsNullOrEmpty(token))
            {
                return new AuthenticationState(new ClaimsPrincipal());
            }

            var claims = ParseClaimsFromJwtToken(token);
            var identity = claims.Count() > 0 ? new ClaimsIdentity(claims) : new ClaimsIdentity();

            var state = new AuthenticationState(new ClaimsPrincipal(identity));
            NotifyAuthenticationStateChanged(Task.FromResult(state));
            return state;
        }

        private IEnumerable<Claim> ParseClaimsFromJwtToken(string token)
        {
            var claims = Enumerable.Empty<Claim>();

            var handler = new JwtSecurityTokenHandler();
            if (handler.CanReadToken(token))
            {
                var securityToken = handler.ReadJwtToken(token);
                claims = securityToken.Claims;
            }

            return claims;
        }
    }
}

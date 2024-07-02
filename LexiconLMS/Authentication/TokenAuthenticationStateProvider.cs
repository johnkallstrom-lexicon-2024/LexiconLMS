using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace LexiconLMS.Authentication
{
    public class TokenAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;
        private readonly ISessionStorageService _sessionStorage;

        public TokenAuthenticationStateProvider(HttpClient httpClient, ISessionStorageService sessionStorage)
        {
            _httpClient = httpClient;
            _sessionStorage = sessionStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string? token = await _sessionStorage.GetItemAsStringAsync("token");
            if (string.IsNullOrWhiteSpace(token))
            {
                var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
                return new AuthenticationState(anonymous);
            }
            else
            {
                var identity = ParseTokenToClaimsIdentity(token);
                var authenticated = new ClaimsPrincipal(identity);

                var state = new AuthenticationState(authenticated);

                return state;
            }
        }

        private ClaimsIdentity ParseTokenToClaimsIdentity(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.ReadJwtToken(token);

            var claims = jwtSecurityToken.Claims.ToList();

            var identity = new ClaimsIdentity(
                claims: claims,
                authenticationType: "jwt");

            return identity;
        }
    }
}

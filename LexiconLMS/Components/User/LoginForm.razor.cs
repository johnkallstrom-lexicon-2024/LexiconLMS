using LexiconLMS.Core.Models.Authenticate;
using LexiconLMS.Core.Results;
using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Components.User
{
    public partial class LoginForm
    {
        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        public string? Token { get; set; }
        public AuthenticateRequest Model { get; set; } = new();

        public async Task Submit()
        {
            var result = await HttpService.PostAsync<Result<string>>(Endpoints.Authenticate, Model);
            if (result != null && result.Success)
            {
                Token = result.Value;
            }
        }
    }
}

using Blazored.LocalStorage;
using LexiconLMS.Core.Models.Authenticate;
using LexiconLMS.Core.Results;
using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Components.User
{
    public partial class LoginForm
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        [Inject]
        public ILocalStorageService LocalStorage { get; set; } = default!;

        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        public AuthenticateRequest? Model { get; set; }

        protected override void OnInitialized()
        {
            Model = new();
        }

        public async Task Submit()
        {
            string? token = await HttpService.PostAndRetrieveString(Endpoints.Authenticate, Model);
            if (!string.IsNullOrWhiteSpace(token))
            {
                await LocalStorage.SetItemAsStringAsync("token", token);
                NavigationManager.NavigateTo("/", forceLoad: true);
            }
        }
    }
}

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

        public AuthenticateRequest Model { get; set; } = new();

        public async Task Submit()
        {
            var response = await HttpService.LoginAsync(Endpoints.Authenticate, Model);
            if (response != null && response.Success)
            {
                await LocalStorage.SetItemAsync("token", response.Token);
                NavigationManager.NavigateTo("/teachers");
            }
        }
    }
}

using Blazored.LocalStorage;
using LexiconLMS.Core.Models.Authenticate;
using LexiconLMS.Core.Results;
using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Components
{
    public partial class Login
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        [Inject]
        public ILocalStorageService LocalStorage { get; set; } = default!;

        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        public List<string> Errors { get; set; } = [];
        public bool Loading { get; set; }
        public AuthenticateRequest Model { get; set; } = new();

        public async Task Submit()
        {
            Loading = true;
            var response = await HttpService.PostLoginAsync(Endpoints.Login, Model);
            if (response != null)
            {
                if (response.Success && !string.IsNullOrEmpty(response.Token))
                {
                    await LocalStorage.SetItemAsStringAsync("token", response.Token);
                    NavigationManager.NavigateTo("/", forceLoad: true);
                }
                else
                {
                    Errors = response.Errors;
                }
            }
            Loading = false;
        }
    }
}

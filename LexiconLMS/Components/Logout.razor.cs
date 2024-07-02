using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Components
{
    public partial class Logout
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        [Inject]
        public ILocalStorageService LocalStorage { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            await LocalStorage.RemoveItemAsync("token");
            NavigationManager.NavigateTo("/logout");
        }
    }
}

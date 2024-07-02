using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Components.Shared
{
    public partial class Navbar
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        [Inject]
        public ISessionStorageService SessionStorage { get; set; } = default!;

        private async Task Logout()
        {
            await SessionStorage.RemoveItemAsync("token");
            NavigationManager.NavigateTo("/logout", forceLoad: true);
        }
    }
}

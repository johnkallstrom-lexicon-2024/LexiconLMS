using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Components.Shared
{
    public partial class Navbar
    {
        [Inject]
        public ILocalStorageService LocalStorage { get; set; } = default!;

        public string? Token { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Token = await LocalStorage.GetItemAsStringAsync("token");
        }
    }
}

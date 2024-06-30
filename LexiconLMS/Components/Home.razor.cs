using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Components
{
    public partial class Home
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

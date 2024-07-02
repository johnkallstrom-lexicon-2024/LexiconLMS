using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Components.Module
{
    public partial class EditModule
    {
        [Parameter]
        public int Id { get; set; }

        public ModuleTrimModel? module { get; set; }

        protected override async Task OnInitializedAsync()
        {
            module = await HttpService.GetAsync<ModuleTrimModel>($"{Endpoints.Modules}/{Id}");
        }

        private async Task OnSubmit()
        {
            if (module != null)
            {
                await HttpService.PutAsync($"{Endpoints.Courses}/{Id}", module);
                NavigationManager.NavigateTo("/modules");
            }
        }

        private void InvalidSubmit()
        {
            // Handle invalid submission
        }
    }
}

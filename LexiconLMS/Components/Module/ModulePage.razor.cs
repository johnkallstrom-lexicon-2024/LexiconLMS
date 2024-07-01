using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LexiconLMS.Components.Module
{
    public partial class ModulePage
    {
        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        [Inject]

        public NavigationManager NavigationManager { get; set; }

        public IEnumerable<ModuleTrimModel> Modules { get; set; } = [];

        protected override async Task OnInitializedAsync()
        {
            var modules = await HttpService.GetAsync<IEnumerable<ModuleTrimModel>>(Endpoints.Modules);
            if (modules != null)
            {
                Modules = modules;
            }
        }

        private void ViewActivitiesByModuleId(int moduleId)
        {
            NavigationManager.NavigateTo($"/modules/{moduleId}/activities");
        }
    }
}

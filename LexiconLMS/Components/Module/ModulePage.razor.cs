using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Components.Module
{
    public partial class ModulePage
    {
        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        public IEnumerable<ModuleModel> Modules { get; set; } = [];

        protected override async Task OnInitializedAsync()
        {
            var modules = await HttpService.GetAsync<IEnumerable<ModuleModel>>(Endpoints.Modules);
            if (modules != null)
            {
                Modules = modules;
            }
        }

        //private void ViewActivities(int moduleId)
        //{
        //    NavigationManager.NavigateTo($"/modules/{moduleId}/activities");
        //}
    }
}

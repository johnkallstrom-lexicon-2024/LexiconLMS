using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Components.Module
{
    public partial class ModulePage
    {
        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        public IEnumerable<ModuleTrimModel> Modules { get; set; } = [];
        public bool Loading { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Loading = true;
            var modules = await HttpService.GetAsync<IEnumerable<ModuleTrimModel>>(Endpoints.Modules);
            if (modules != null)
            {
                Modules = modules;
            }
            Loading = false;
        }
    }
}

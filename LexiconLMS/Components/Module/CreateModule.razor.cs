using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Components.Module
{
    public partial class CreateModule
    {
        [SupplyParameterFromForm]
        public ModuleTrimModel Module { get; set; }


        [Inject]
        public IHttpService? HttpService { get; set; }
        protected string Message = string.Empty;
        protected string ErrorMessage = string.Empty;
        protected bool IsSaved = false;
        protected override void OnInitialized()
        {
            Module ??= new();
        }
        public async Task OnSumbit()
        {
            await HttpService.PostAsync(Endpoints.Modules, Module);
            IsSaved = true;
            if (IsSaved)
            {
                Message = "Module added successfully";
                NavigationManager.NavigateTo("/modules");
            }
            else
            {
                ErrorMessage = "There was an error";
            }
        }
    }
}

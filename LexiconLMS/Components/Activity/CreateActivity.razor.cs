using LexiconLMS.Core.Models.Activity;
using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Components.Activity
{
    public partial class CreateActivity
    {

        [Parameter]
        public int ModuleId { get; set; }

        [SupplyParameterFromForm]
        private ActivityCreateModel Activity { get; set; } = new();
        private string Message { get; set; } = string.Empty;
        private bool IsSaved { get; set; } = false;

        [Inject]
        public IHttpService HttpService { get; set; }

        [Inject] 
        NavigationManager NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            Activity.ModuleId = ModuleId; // Set the ModuleId for the new activity
        }

        private async Task OnSubmit()
        {
            try
            {
                await HttpService.PostAsync("api/activities", Activity);
                IsSaved = true;
                Message = "Activity successfully added!";
            }
            catch (Exception ex)
            {
                Message = $"Error: {ex.Message}";
            }
        }
        private void NavigateBackToActivities()
        {
            NavigationManager.NavigateTo($"/modules/{ModuleId}/activities");
        }
    }
}

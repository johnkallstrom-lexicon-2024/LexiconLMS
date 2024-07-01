using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Components.Activity
{
    public partial class ActivityPage
    {
        [Parameter]
        public int ModuleId { get; set; }
        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        public IEnumerable<ActivityModelForFiltering> Activity { get; set; } = [];

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var activities = await HttpService.GetAsync<IEnumerable<ActivityModelForFiltering>>(Endpoints.Activities);
                if (activities != null)
                {
                    // Filter activities by moduleId
                    Activity = activities.Where(a => a.Module.Id == ModuleId).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching activities: {ex.Message}");
            }
        }
    }
}

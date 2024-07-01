using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Components.Activity
{
    public partial class ActivityByModuleIdPage
    {
        [Parameter]
        public int ModuleId { get; set; }
        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        public IEnumerable<ActivityModelForFiltering> Activity { get; set; } = [];

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var activities = await HttpService.GetAsync<IEnumerable<ActivityModelForFiltering>>(Endpoints.Activities);
                if (activities != null)
                {
                    // Filter activities by moduleId
                    Activity = activities;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching activities: {ex.Message}");
            }
        }
    }
}

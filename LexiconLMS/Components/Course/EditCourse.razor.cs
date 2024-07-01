using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Components.Course
{
    public partial class EditCourse
    {
        [Parameter]
        public int Id { get; set; }

        [SupplyParameterFromForm]
        public CourseUpdateModel Course { get; set; }
 
        protected bool IsSaved;
        protected override async Task OnInitializedAsync()
        {
            IsSaved = false;
            Course = await HttpService.GetAsync<CourseUpdateModel>($"{Endpoints.Courses}/{Id}");
            
        }

        protected async Task EditCourseAsync()
        {
            await HttpService.PutAsync($"{Endpoints.Courses}/{Id}", Course);
            NavigationManager.NavigateTo("/courses");
        }

        protected async Task HandleValidSubmit()
        {
            await HttpService.PutAsync($"{Endpoints.Courses}/{Id}", Course);
            IsSaved = true;
        }

        protected async Task HandleInvalidSubmit()
        {

        }
    }
}

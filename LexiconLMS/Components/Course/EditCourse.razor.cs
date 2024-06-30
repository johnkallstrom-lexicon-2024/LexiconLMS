using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Components.Course
{
    public partial class EditCourse
    {
        [Parameter]
        public int Id { get; set; }

        private CourseUpdateModel Course = new CourseUpdateModel();

        protected override async Task OnInitializedAsync()
        {
            Course = await HttpService.GetAsync<CourseUpdateModel>($"{Endpoints.Courses}/{Id}");
        }

        private async Task EditCourseAsync()
        {
            await HttpService.PutAsync($"{Endpoints.Courses}/{Id}", Course);
            NavigationManager.NavigateTo("/teachers");
        }
    }
}

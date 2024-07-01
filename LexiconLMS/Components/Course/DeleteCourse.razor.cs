using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Components.Course
{
    public partial class DeleteCourse
    {
        [Parameter]
        public int Id { get; set; }

        private async Task DeleteCourseAsync()
        {
            await HttpService.DeleteAsync($"{Endpoints.Courses}/{Id}");
            NavigationManager.NavigateTo("/teachers");
        }

        private void Cancel()
        {
            NavigationManager.NavigateTo("/courses");
        }
    }
}

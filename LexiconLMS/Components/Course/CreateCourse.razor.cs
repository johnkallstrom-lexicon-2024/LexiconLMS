using Microsoft.AspNetCore.Components;
namespace LexiconLMS.Components.Course
{
    public partial class CreateCourse
    {
        [SupplyParameterFromForm]
        public CourseCreateModel Course { get; set ; }

        [Inject]
        public IHttpService? HttpService { get; set; }

        protected override void OnInitialized()
        {
            Course ??= new();
        }
        public async Task OnSumbit()
        {
            await HttpService.PostAsync(Endpoints.Courses, Course);
            NavigationManager.NavigateTo("/teachers");
        }
      
    }
}

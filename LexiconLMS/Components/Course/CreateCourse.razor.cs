using Microsoft.AspNetCore.Components;
namespace LexiconLMS.Components.Course
{
    public partial class CreateCourse
    {
        [SupplyParameterFromForm]
        public CourseCreateModel Course { get; set ; }

       
        [Inject]
        public IHttpService? HttpService { get; set; }
        protected string Message = string.Empty;
        protected string ErrorMessage = string.Empty;
        protected bool IsSaved = false;
        protected override void OnInitialized()
        {
            Course ??= new();
        }
        public async Task OnSumbit()
        {
            await HttpService.PostAsync(Endpoints.Courses, Course);
            IsSaved = true;
            if (IsSaved)
            {
                Message = "Course added successfully";
                NavigationManager.NavigateTo("/teachers");
            }
            else
            {
                ErrorMessage = "There was an error";
            }
    
           
            
        }
      
    }
}

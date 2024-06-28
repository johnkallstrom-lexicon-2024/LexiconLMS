using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Components.Course
{
    public partial class CoursePage
    {
        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        public IEnumerable<CourseTrimModel> Courses { get; set; } = [];

        protected override async Task OnInitializedAsync()
        {
            var courses = await HttpService.GetAsync<IEnumerable<CourseTrimModel>>(Endpoints.Courses);
            if (courses != null)
            {
                Courses = courses;
            }
        }
    }
}

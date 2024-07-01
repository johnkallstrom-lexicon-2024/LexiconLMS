using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Components.Course
{
    public partial class CoursePage
    {
        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        public IEnumerable<CourseTrimModel> Courses { get; set; } = [];
        public bool Loading { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Loading = true;
            var courses = await HttpService.GetAsync<IEnumerable<CourseTrimModel>>(Endpoints.Courses);
            if (courses != null)
            {
                Courses = courses;
            }
            Loading = false;
        }
    }
}

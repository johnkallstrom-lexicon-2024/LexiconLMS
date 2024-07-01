using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Components.Student
{
    public partial class StudentPage
    {
        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        public IEnumerable<UserTrimModel> Model { get; set; } = [];
        public bool Loading { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await GetStudents();
        }

        private async Task GetStudents()
        {
            Loading = true;
            var students = await HttpService.GetAsync<IEnumerable<UserTrimModel>>($"{Endpoints.Users}?role=Student");
            if (students != null)
            {
                Model = students;
            }
            Loading = false;
        }
    }
}

using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Components.User.Teacher
{
    public partial class TeacherPage
    {
        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        public IEnumerable<UserTrimModel> Model { get; set; } = [];
        public bool Loading { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await GetTeachers();
        }

        private async Task GetTeachers()
        {
            Loading = true;
            var teachers = await HttpService.GetAsync<IEnumerable<UserTrimModel>>($"{Endpoints.Users}?role=Teacher");
            if (teachers != null)
            {
                Model = teachers;
            }
            Loading = false;
        }
    }
}

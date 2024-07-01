using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Components.Teacher
{
    public partial class TeacherDetailsPage
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        [Parameter]
        public int Id { get; set; }

        public bool Loading { get; set; }
        public UserModel Model { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            await GetTeacher();
        }

        private void Return() => NavigationManager.NavigateTo("/teachers");

        private async Task GetTeacher()
        {
            Loading = true;
            var teacher = await HttpService.GetAsync<UserModel>($"{Endpoints.Users}/{Id}");
            if (teacher != null)
            {
                Model = teacher;
            }
            Loading = false;
        }
    }
}

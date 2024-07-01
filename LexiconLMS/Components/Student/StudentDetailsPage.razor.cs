using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Components.Student
{
    public partial class StudentDetailsPage
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
            await GetStudent();
        }

        private void Return() => NavigationManager.NavigateTo("/students");

        private async Task GetStudent()
        {
            Loading = true;
            var student = await HttpService.GetAsync<UserModel>($"{Endpoints.Users}/{Id}");
            if (student != null)
            {
                Model = student;
            }
            Loading = false;
        }
    }
}

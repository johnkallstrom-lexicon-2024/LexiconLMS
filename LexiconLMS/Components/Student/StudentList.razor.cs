using static System.Net.WebRequestMethods;

namespace LexiconLMS.Components.UserModel
{
    partial class StudentList
    {
        private List<Core.Models.User.UserModel> _users;
        /*protected override async Task OnInitializedAsync()
        {
            _users = await Http.GetFromJsonAsync<List<UserModel>>("https://yourapiendpoint.com/api/student");
        }*/
    }
}

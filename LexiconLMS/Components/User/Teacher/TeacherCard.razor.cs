using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Components.User.Teacher
{
    public partial class TeacherCard
    {
        [Parameter]
        public UserTrimModel Teacher { get; set; } = default!;
    }
}

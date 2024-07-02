using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Components.Teacher
{
    public partial class TeacherCard
    {
        [Parameter]
        public UserTrimModel Teacher { get; set; } = default!;
    }
}

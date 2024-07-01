using Microsoft.AspNetCore.Components;

namespace LexiconLMS.Components.User.Student
{
    public partial class StudentCard
    {
        [Parameter]
        public UserTrimModel Student { get; set; } = default!;
    }
}

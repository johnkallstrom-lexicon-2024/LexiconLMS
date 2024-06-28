using LexiconLMS.Core.Models.Course;
using LexiconLMS.Core.Models.Document;

namespace LexiconLMS.Core.Models.User
{
    public class UserModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }

        public CourseModel Course { get; set; } = default!;
        public IEnumerable<string> Roles { get; set; } = [];
        public IEnumerable<DocumentModel> Documents { get; set; } = default!;
    }
}

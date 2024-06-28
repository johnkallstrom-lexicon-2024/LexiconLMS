using LexiconLMS.Core.Models.Activity;
using LexiconLMS.Core.Models.Course;
using LexiconLMS.Core.Models.Module;
using LexiconLMS.Core.Models.User;

namespace LexiconLMS.Core.Models.Document
{
    public class DocumentModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime UploadedAt { get; set; }

        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }

        public UserModel User { get; set; } = default!;
        public CourseModel Course { get; set; } = default!;
        public ModuleModel Module { get; set; } = default!;
        public ActivityModel Activity { get; set; } = default!;
    }
}

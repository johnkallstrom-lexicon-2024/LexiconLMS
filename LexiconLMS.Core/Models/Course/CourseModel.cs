using LexiconLMS.Core.Models.Document;
using LexiconLMS.Core.Models.Module;
using LexiconLMS.Core.Models.User;

namespace LexiconLMS.Core.Models.Course
{
    public class CourseModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }

        public IEnumerable<UserModel> Users { get; set; } = [];
        public IEnumerable<ModuleModel> Modules { get; set; } = [];
        public IEnumerable<DocumentModel> Documents { get; set; } = [];
    }
}

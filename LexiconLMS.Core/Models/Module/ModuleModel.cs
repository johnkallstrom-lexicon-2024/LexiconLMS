using LexiconLMS.Core.Models.Activity;
using LexiconLMS.Core.Models.Course;

namespace LexiconLMS.Core.Models.Module
{
    public class ModuleModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }

        public CourseTrimModel Course { get; set; } = default!;
        public ICollection<ActivityTrimModel> Activities { get; set; } = [];
    }
}
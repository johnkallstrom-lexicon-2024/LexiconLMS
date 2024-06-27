namespace LexiconLMS.Core.Models
{
    public class ModuleModel
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public CourseModel Course { get; set; } = default!;
        public IEnumerable<ActivityModel> Activities { get; set; } = [];
    }
}
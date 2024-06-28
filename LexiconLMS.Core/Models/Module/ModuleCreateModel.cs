namespace LexiconLMS.Core.Models.Module
{
    public class ModuleCreateModel
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int CourseId { get; set; }
    }
}

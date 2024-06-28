namespace LexiconLMS.Core.Models.Activity
{
    public class ActivityCreateModel
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public ActivityType Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int ModuleId { get; set; }
    }
}

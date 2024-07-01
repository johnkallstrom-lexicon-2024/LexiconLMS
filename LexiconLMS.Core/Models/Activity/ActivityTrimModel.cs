namespace LexiconLMS.Core.Models.Activity
{
    public class ActivityTrimModel : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public ActivityType Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Module { get; set; } = default!;

        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }

    }
}

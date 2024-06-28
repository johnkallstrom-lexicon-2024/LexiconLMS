using LexiconLMS.Core.Models.Document;
using LexiconLMS.Core.Models.Module;

namespace LexiconLMS.Core.Models.Activity
{
    public class ActivityModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public ActivityType Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }

        public ModuleTrimModel Module { get; set; } = default!;
        public IEnumerable<DocumentTrimModel> Documents { get; set; } = default!;
    }
}

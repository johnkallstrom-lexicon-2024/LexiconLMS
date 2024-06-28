using LexiconLMS.Core.Models.Document;
using LexiconLMS.Core.Models.Module;
using System.Text.Json.Serialization;

namespace LexiconLMS.Core.Models.Activity
{
    public class ActivityModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ActivityType Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }

        public ModuleModel Module { get; set; } = default!;
        public IEnumerable<DocumentModel> Documents { get; set; } = default!;
    }
}

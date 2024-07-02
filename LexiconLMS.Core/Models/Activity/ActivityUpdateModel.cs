using System.Text.Json.Serialization;

namespace LexiconLMS.Core.Models.Activity
{
    public class ActivityUpdateModel : BaseModel
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ActivityType Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int ModuleId { get; set; }
    }
}

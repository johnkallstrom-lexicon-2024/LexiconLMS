using LexiconLMS.Core.Models.User;

namespace LexiconLMS.Core.Models.Document
{
    public class DocumentModel : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime UploadedAt { get; set; }

        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }

        public UserTrimModel User { get; set; } = default!;
    }
}

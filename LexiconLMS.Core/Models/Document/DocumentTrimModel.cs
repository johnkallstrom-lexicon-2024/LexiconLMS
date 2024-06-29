namespace LexiconLMS.Core.Models.Document
{
    public class DocumentTrimModel : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime UploadedAt { get; set; }
    }
}

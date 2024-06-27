namespace LexiconLMS.Core.Models
{
    public class DocumentModel
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime UploadTime { get; set; }
    }
}

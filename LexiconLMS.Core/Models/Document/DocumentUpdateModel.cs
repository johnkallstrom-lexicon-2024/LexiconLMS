namespace LexiconLMS.Core.Models.Document
{
    public class DocumentUpdateModel
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime UploadTime { get; set; }
    }
}

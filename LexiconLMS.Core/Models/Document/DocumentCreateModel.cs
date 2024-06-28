namespace LexiconLMS.Core.Models.Document
{
    public class DocumentCreateModel
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime UploadTime { get; set; }

        public int? UserId { get; set; }
        public int? CourseId { get; set; }
        public int? ModuleId { get; set; }
        public int? ActivityId { get; set; }
    }
}

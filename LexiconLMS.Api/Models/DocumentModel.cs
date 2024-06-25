using System.ComponentModel.DataAnnotations;

namespace LexiconLMS.Api.Models
{
    public class DocumentModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime UploadTime { get; set; }

        public int? UserId { get; set; }
        public int? CourseId { get; set; }
        public int? ModuleId { get; set; }
        public int? ActivityId { get; set; }
    }
}

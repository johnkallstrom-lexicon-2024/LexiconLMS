using LexiconLMS.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace LexiconLMS.Api.Models
{
    public class ModuleModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int CourseId { get; set; }
    }
}

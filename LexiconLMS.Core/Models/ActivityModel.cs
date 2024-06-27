using LexiconLMS.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace LexiconLMS.Api.Models
{
    public class ActivityModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public ActivityType Type { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int ModuleId { get; set; }
    }
}

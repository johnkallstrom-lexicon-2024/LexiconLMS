namespace LexiconLMS.Core.Entities
{
    public class Document : BaseEntity
    {
        [Required]
        [MinLength(length: 3)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MinLength(length: 3)]
        public string Description { get; set; } = string.Empty;
        
        public DateTime UploadTime { get; set; }

        // Computed property
        public string SearchableString => $"{Name} {Description} {UploadTime:yyyy-MM-dd}";
    }
}

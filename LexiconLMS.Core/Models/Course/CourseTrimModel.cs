namespace LexiconLMS.Core.Models.Course
{
    public class CourseTrimModel : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
    }
}

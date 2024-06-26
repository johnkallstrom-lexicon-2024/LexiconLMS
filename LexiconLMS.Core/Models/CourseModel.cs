namespace LexiconLMS.Core.Models
{
    public class CourseModel
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public IEnumerable<UserModel> Users { get; set; } = [];
    }
}

namespace LexiconLMS.Core.Models.Module
{
    public class ModuleTrimModel : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

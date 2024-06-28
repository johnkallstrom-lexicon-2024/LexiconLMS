namespace LexiconLMS.Core.Models.User
{
    public class RoleModel : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
    }
}

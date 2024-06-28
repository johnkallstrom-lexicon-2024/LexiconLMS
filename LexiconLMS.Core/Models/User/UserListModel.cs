namespace LexiconLMS.Core.Models.User
{
    public class UserListModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public IEnumerable<string> Roles { get; set; } = [];
    }
}

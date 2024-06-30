using LexiconLMS.Core.Models.Authenticate;

namespace LexiconLMS.Components.User
{
    public partial class LoginForm
    {
        public AuthenticateRequest Model { get; set; } = new();
    }
}

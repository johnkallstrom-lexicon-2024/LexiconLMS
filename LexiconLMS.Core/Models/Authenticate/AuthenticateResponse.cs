using System.Text.Json.Serialization;

namespace LexiconLMS.Core.Models.Authenticate
{
    public class AuthenticateResponse
    {
        public bool Success { get; set; }
        [JsonPropertyName("Value")]
        public string? Token { get; set; }
        public List<string> Errors { get; set; } = [];
    }
}

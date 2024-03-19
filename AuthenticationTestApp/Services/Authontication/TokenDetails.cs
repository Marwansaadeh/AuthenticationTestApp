using System.Text.Json.Serialization;

namespace AuthenticationTestApp.Services.Authontication
{
    public class TokenDetails
    {
        [JsonPropertyName("Status")]
        public string Status { get; set; } = string.Empty;

        [JsonPropertyName("token")]
        public string Token { get; set; } = string.Empty;

        [JsonPropertyName("refreshtoken")]
        public string Refreshtoken { get; set; } = string.Empty;

        [JsonPropertyName("expireTime")]
        public string ExpireTime { get; set; } = string.Empty;


    }
}

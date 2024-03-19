using AuthenticationTestApp.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace AuthenticationTestApp.Services.Authontication
{
    public class AuthonticationToken : IAuthonticationToken
    {
        public async Task<string> GetToken(InputLogInModel userLoginInput, string authUrl)
        {
            var form = new Dictionary<string, string>
                {
                    { "username",userLoginInput.UserName },
                    { "password", userLoginInput.Password },
                };

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("cache-control", "no-cache");

            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, authUrl);

            req.Content = new FormUrlEncodedContent(form);
            req.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

            HttpResponseMessage tokenResponse = await client.SendAsync(req);

            if (!tokenResponse.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Call to get Token with HttpClient failed.");
            }

            var jsonContent = await tokenResponse.Content.ReadAsStringAsync();
            TokenDetails? tokenDetails = JsonSerializer.Deserialize<TokenDetails>(jsonContent);
            return tokenDetails.Token;
        }
    }
}

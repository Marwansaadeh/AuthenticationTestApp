using AuthenticationTestApp.Models;

namespace AuthenticationTestApp.Services.Authontication
{
    public interface IAuthonticationToken
    {
        public Task<string> GetToken(InputLogInModel inputLogIn, string authUrl);
    }
}

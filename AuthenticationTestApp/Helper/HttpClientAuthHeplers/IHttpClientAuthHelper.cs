namespace AuthenticationTestApp.Helper.HttpClientHeplers
{
    public interface IHttpClientAuthHelper
    {
        public HttpClient CallAuthonticationClient(string token);    
    }
}

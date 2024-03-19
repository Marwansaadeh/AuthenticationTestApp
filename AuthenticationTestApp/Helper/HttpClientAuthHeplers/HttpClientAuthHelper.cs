namespace AuthenticationTestApp.Helper.HttpClientHeplers
{
    public class HttpClientAuthHelper: IHttpClientAuthHelper
    {
        public HttpClient CallAuthonticationClient(string token)
        {
            var client = new HttpClient();
            
               client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
               return client;
           
        }
    }
}

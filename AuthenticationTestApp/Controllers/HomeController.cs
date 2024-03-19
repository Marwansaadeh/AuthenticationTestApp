using AuthenticationTestApp.Helper;
using AuthenticationTestApp.Helper.HttpClientHeplers;
using AuthenticationTestApp.Models;
using AuthenticationTestApp.Services.Authontication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace AuthenticationTestApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAuthonticationToken _authonticationToken;
        private readonly IOptions<ApplicationUrlsOptions> _urlOption;
        private readonly IHttpClientAuthHelper _httpClientAuthHelper;

        public HomeController(ILogger<HomeController> logger, IAuthonticationToken authonticationToken, IOptions<ApplicationUrlsOptions> urlOption, IHttpClientAuthHelper httpClientAuthHelper)
        {
            _logger = logger;
            _authonticationToken = authonticationToken;
            _urlOption = urlOption;
            _httpClientAuthHelper = httpClientAuthHelper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Index(InputLogInModel model)
        {
           string? tokenUrl = _urlOption.Value.TokenUrl;

           if (string.IsNullOrEmpty(tokenUrl))
            {
                throw new ArgumentNullException(nameof(tokenUrl));
            }

            var token = await _authonticationToken.GetToken(model, tokenUrl);
            var client= _httpClientAuthHelper.CallAuthonticationClient(token);

            var response = await client.GetFromJsonAsync<ImageResonseDetails>(_urlOption.Value.ImageURL);
            client.Dispose();

            ViewBag.ImageBase64Code = response?.Data;
            
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using gitProfilePOC1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace gitProfilePOC1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new GitUserProfile());
        }

        [HttpPost]
        public async Task<ActionResult> Index(string username)
        {
            var _gitUserProfile = new GitUserProfile();

            string apiUrl = "https://api.github.com/users/" + username;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Add("User-Agent", "request");

                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var _data = await response.Content.ReadAsStringAsync();
                        _gitUserProfile = Newtonsoft.Json.JsonConvert.DeserializeObject<GitUserProfile>(_data);

                        if (_gitUserProfile != null && !string.IsNullOrEmpty(_gitUserProfile.repos_url))
                        {
                            using (HttpClient clientRepo = new HttpClient())
                            {
                                clientRepo.BaseAddress = new Uri(_gitUserProfile.repos_url);
                                clientRepo.DefaultRequestHeaders.Add("User-Agent", "request");

                                HttpResponseMessage responseRepo = await clientRepo.GetAsync(_gitUserProfile.repos_url);
                                if (responseRepo.IsSuccessStatusCode)
                                {
                                    var _dataRepo = await responseRepo.Content.ReadAsStringAsync();
                                    var _gitUserRepos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<GitUserRepos>>(_dataRepo);
                                    if (_gitUserRepos != null && _gitUserRepos.Count > 0)
                                    {
                                        _gitUserProfile.repos = _gitUserRepos.OrderByDescending(x => x.stargazers_count).Take(5).ToList();
                                    }
                                }
                            }
                        }
                    }
                    _gitUserProfile.httpStatus = response.StatusCode;
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }

            return View("Index", _gitUserProfile);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
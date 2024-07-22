using ASPfirtsMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace ASPfirtsMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task <IActionResult> Index()
        {
            List<Post> posts = new List<Post>();
            string url = "https://jsonplaceholder.typicode.com/posts";
            var client = new HttpClient();
            var response = await client.GetAsync(url); 
            var body = await response.Content.ReadAsStringAsync();
            posts = JsonSerializer.Deserialize<List<Post>>(body); 
            return View("Index", posts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Vista2()
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

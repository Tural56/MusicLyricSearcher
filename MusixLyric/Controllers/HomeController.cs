using Microsoft.AspNetCore.Mvc;
using MusixLyric.Models;
using System.Diagnostics;

namespace MusixLyric.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Index(string Name)
        {
            var items = LyricListSender.getLyricList(Name);
            return View(items);
        }

        public IActionResult GetDetail(string Link)
        {
            var lyric = LyricSender.getLyric(Link);
            return View(lyric);
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
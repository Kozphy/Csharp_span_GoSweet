using GoSweet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GoSweet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly shopwebContext _shopwebContext;

        public HomeController(ILogger<HomeController> logger, shopwebContext shopwebContext)
        {
            _logger = logger;
            _shopwebContext = shopwebContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login() 
        {
            return View();
        }

        public IActionResult SignUp() {
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
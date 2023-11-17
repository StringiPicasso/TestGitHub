using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TraningCode.Models;

namespace TraningCode.Controllers
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
            return View();
        }

        [HttpGet]
        public IActionResult PiNumber()
        {


            return View();
        }

        [HttpPost]
        public IActionResult PiNumber(NumberBody number)
        {
            var inputNumber = new NumberBody();
          
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
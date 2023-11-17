using CatalogOfFootballPlayers.Database;
using CatalogOfFootballPlayers.Models;
using FootbalTeams.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CatalogOfFootballPlayers.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext db)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Player> objPlayerList = _db.Players;

            return View(objPlayerList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<Player> objPlayerList = _db.Players;
            return View(objPlayerList);
        }

        [HttpPost]
        public IActionResult Create(Player player)
        {
            if (ModelState.IsValid)
            {
            _db.Players.Add(player);
            _db.SaveChanges();

            return RedirectToAction("Index");
            }

            return View(player);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var playerFromDb = _db.Players.Find(id);

            if(playerFromDb == null)
            {
                return NotFound();
            }

            return View(playerFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Player player)
        {
            if (ModelState.IsValid)
            {
                _db.Players.Update(player);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(player);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
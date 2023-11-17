﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TeeamFootballProject.DataBase;
using TeeamFootballProject.Models;

namespace TeeamFootballProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Player> objPlayerList = _db.Players.Include(t=>t.NameTeam);
          
            return View(objPlayerList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Teams = new SelectList(_db.Teams, "Id", "NameOfTeam");

            return View();
        }

        [HttpPost]
        public IActionResult Create(Player player)
        {
            if (!ModelState.IsValid || _db.Teams.Where(x => x.NameOfTeam == player.NameTeam.NameOfTeam).Count() > 0)
            {
                _db.Teams.Add(player.NameTeam);
                _db.SaveChanges();
                ViewBag.Teams = new SelectList(_db.Teams, "Id", "NameOfTeam");

                return View();
            }

            _db.Players.Add(player);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var playerFromDb = _db.Players.Find(id);

            if (playerFromDb == null)
            {
                return NotFound();
            }
            ViewBag.Teams = new SelectList(_db.Teams, "Id", "NameOfTeam");

            return View(playerFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Player player)
        {
            if (!ModelState.IsValid || _db.Teams.Where(x => x.NameOfTeam == player.NameTeam.NameOfTeam).Count() > 0)
            {
                _db.Teams.Add(player.NameTeam);
                _db.SaveChanges();
                ViewBag.Teams = new SelectList(_db.Teams, "Id", "NameOfTeam");

                return View(player);
            }

            _db.Players.Update(player);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
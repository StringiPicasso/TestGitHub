﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Numerics;
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
        public Task<IActionResult> Index()
        {
            IEnumerable<Player> objPlayerList = _db.Players.Include(t=>t.NameTeam);
          
            return Task.FromResult<IActionResult>(View(objPlayerList));
        }

        [HttpGet]
        public Task<IActionResult> Create()
        {
           // var player=new Player();
            //ViewBag.TeamsId = GetTeams();
            //var teams = await _db.Players.Where(t => t.NameTeam == null).ToListAsync();
            ViewData["TeamId"] = new SelectList(_db.Teams, "Id", "NameOfTeam");

          //  return View();
           // ViewBag.TeamsId = new SelectList(_db.Teams, "Id", "NameOfTeam");
            //ViewData["Teams"] = new SelectList(_db.Teams, "Id", "NameOfTeam");
            return Task.FromResult<IActionResult>(View());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Player player)
        {
            if (ModelState.IsValid)
            {

                _db.Players.Add(player);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();

            //if (ModelState.IsValid)
            //{
            //    _db.Players.Add(player);
            //    await _db.SaveChangesAsync();

            //    return RedirectToAction("Index");

            //}

            //if(_db.Teams.Where(x => x.NameOfTeam == player.NameTeam.NameOfTeam).Count() > 0)
            //{
            //    _db.Teams.Add(player.NameTeam);
            //    await _db.SaveChangesAsync();
            //    ViewData["TeamId"] = new SelectList(_db.Teams, "Id", "NameOfTeam", player.TeamId);


            //    return View();
            //}
            //ViewData["TeamId"] = new SelectList(_db.Teams, "Id", "NameOfTeam", player.TeamId);
           
            //return View();
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

        private List<SelectListItem> GetTeams()
        {
            var listTeams = new List<SelectListItem>();

            List<TeamNames> teamNames = _db.Teams.ToList();

            listTeams = teamNames.Select(t => new SelectListItem()
            {
                Value = t.Id.ToString(),
                Text=t.NameOfTeam
            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "select item"
            };

            listTeams.Insert(0, defItem);

            return listTeams;
        }
    }
}
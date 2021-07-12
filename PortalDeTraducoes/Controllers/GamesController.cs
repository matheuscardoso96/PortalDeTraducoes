using Microsoft.AspNetCore.Mvc;
using PortalDeTraducoes.Context;
using PortalDeTraducoes.Models.ViewModels;
using PortalDeTraducoes.Models.InputModels;
using PortalDeTraducoes.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PortalDeTraducoes.Controllers
{
    public class GamesController : Controller
    {
        private readonly DataContext _portalContext;
        public GamesController(DataContext portalContext)
        {
            _portalContext = portalContext;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _portalContext.Games.Select(game => new GameViewModel { 
                ID = game.ID, 
                Title = game.Title,
                RealeaseDate = game.ReleaseDate,
                Translations = game.Translations,
                Developers = game.Developers, 
                Platforms = game.Platforms, 
                Publishers = game.Publishers }).ToListAsync());
        }

        public async Task<IActionResult> Game(string title)
        {
            var game = await _portalContext.Games.FirstOrDefaultAsync(g => g.Title.Contains(title));
            var gameViewModel = new GameViewModel { ID = game.ID, Title = game.Title, RealeaseDate = game.ReleaseDate, Translations = game.Translations, Developers = game.Developers, Platforms = game.Platforms, Publishers = game.Publishers  };
            return View(gameViewModel);
        }

        public async Task<IActionResult> NewGame()
        {
            ViewBag.Platforms = new MultiSelectList(await _portalContext.Platforms.ToListAsync(), "ID", "Name");
            return  View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterGame([Bind("ID", "Title", "ReleaseDate", "Genres", "Developers", "Publishers")] GameInputModel game, int[] platformsId)
        {
            return RedirectToAction("Index");
        }
    }
}

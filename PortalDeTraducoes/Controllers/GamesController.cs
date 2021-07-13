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
using Microsoft.AspNetCore.Authorization;

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
            var game = await _portalContext.Games.Where(g => g.Title == title).Include(g => g.Platforms).Include(g => g.Developers).Include(g => g.Publishers).Include(g => g.Genre).Include(g => g.Translations).FirstOrDefaultAsync();
            var gameViewModel = new GameViewModel { ID = game.ID, Title = game.Title, CoverArtUrl = game.CoverArtUrl, Genres = game.Genre, RealeaseDate = game.ReleaseDate, Translations = game.Translations, Developers = game.Developers, Platforms = game.Platforms, Publishers = game.Publishers  };
            return View(gameViewModel);
        }
        
        [Authorize]
        public async Task<IActionResult> NewGame()
        {
            ViewBag.Platforms = new MultiSelectList(await _portalContext.Platforms.ToListAsync(), "ID", "Name");
            ViewBag.Genres = new MultiSelectList(await _portalContext.Genres.ToListAsync(), "ID", "Name");
            return  View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterGame([Bind("ID", "Title","CovertArtUrl" ,"ReleaseDate", "Genres", "Developers", "Publishers", "PlatformsId", "GenresId")] GameInputModel game)
        {
            var newGame = new Game(game.Title,game.ReleaseDate, game.CovertArtUrl, game.ID);
            for (int i = 0; i < game.PlatformsId.Length; i++)
                newGame.AddPlatform(await _portalContext.Platforms.Where(x => x.ID == game.PlatformsId[i]).FirstOrDefaultAsync());
            
            for (int i = 0; i < game.GenresId.Length; i++)
                newGame.AddGenre(await _portalContext.Genres.Where(x => x.ID == game.GenresId[i]).FirstOrDefaultAsync());

            string[] developers = game.Developers.Split(',');
            string[] publishers = game.Publishers.Split(',');

            for (int i = 0; i < developers.Length; i++)
            {
                var developer = await _portalContext.Developers.Where(dev => dev.Name == developers[i]).FirstOrDefaultAsync();
                if (developer == null) 
                {
                    developer = new Developer(developers[i], "", 0);
                    _portalContext.Developers.Add(developer);
                }

                newGame.AddDeveloper(developer);
            }

            for (int i = 0; i < publishers.Length; i++)
            {
                var publisher = await _portalContext.Publishers.Where(pub => pub.Name == publishers[i]).FirstOrDefaultAsync();
                if (publisher == null)
                {
                    publisher = new Publisher(publishers[i], "", 0);
                    _portalContext.Publishers.Add(publisher);
                }

                newGame.Publishers.Add(publisher);
            }

            _portalContext.Games.Add(newGame);

            await _portalContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using PortalDeTraducoes.Context;
using PortalDeTraducoes.Models.ViewModels;
using PortalDeTraducoes.Models.InputModels;
using PortalDeTraducoes.Models.Entities;
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

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _portalContext.Games.Include(p => p.Platforms).Select(game => new GameViewModel { 
                ID = game.ID, 
                Title = game.Title,
                Platforms = game.Platforms.Select(p => p.Name).ToList()
            }).ToListAsync());
        }


        [AllowAnonymous]
        public async Task<IActionResult> Game(int id)
        {
            var game = await _portalContext.Games.Where(g => g.ID == id)
                .Include(g => g.Platforms).Include(g => g.Developers)
                .Include(g => g.Publishers).Include(g => g.Genre)
                .Include(g => g.Translations).FirstOrDefaultAsync();


            var gameViewModel = new GameViewModel { 
                ID = game.ID, 
                Title = game.Title, 
                CoverArtUrl = game.CoverArtUrl, 
                Genres = game.Genre.Select(ge => ge.Name).ToList(), 
                RealeaseDate = game.ReleaseDate, 
                Translations = game.Translations.Select(t => t.ID.ToString()).ToList(), 
                Developers = game.Developers.Select(dev => dev.Name).ToList(), 
                Platforms = game.Platforms.Select(pl => pl.Name).ToList(), 
                Publishers = game.Publishers.Select(pub => pub.Name).ToList()
            };
            return View(gameViewModel);
        }
        
   
        public async Task<IActionResult> NewGame()
        {
            ViewBag.Platforms = new MultiSelectList(await _portalContext.Platforms.ToListAsync(), "ID", "Name");
            ViewBag.Genres = new MultiSelectList(await _portalContext.Genres.ToListAsync(), "ID", "Name");
            return  View();
        }

        public JsonResult GetDevelopers(string term)
        {
            var users = _portalContext.Developers.Where(dev => dev.Name.Contains(term)).Select(dev => dev.Name);

            return Json(users);
        }

        public JsonResult GetPublishers(string term)
        {
            var users = _portalContext.Publishers.Where(dev => dev.Name.Contains(term)).Select(dev => dev.Name);

            return Json(users);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterGame(GameInputModel game)
        {
            if (!ModelState.IsValid)
                return View(game);
            

           // var newGame = new Game(game.Title,game.ReleaseDate, game.CovertArtUrl);
           // for (int i = 0; i < game.PlatformsId.Length; i++)
           //     newGame.AddPlatform(await _portalContext.Platforms.Where(x => x.ID == game.PlatformsId[i]).FirstOrDefaultAsync());
            
           // for (int i = 0; i < game.GenresId.Length; i++)
           //     newGame.AddGenre(await _portalContext.Genres.Where(x => x.ID == game.GenresId[i]).FirstOrDefaultAsync());

           // string[] developers = game.Developers.Split(',');
           // string[] publishers = game.Publishers.Split(',');

           // for (int i = 0; i < developers.Length; i++)
           // {
           //     var developer = await _portalContext.Developers.Where(dev => dev.Name == developers[i]).FirstOrDefaultAsync();
           //     if (developer == null) 
           //     {
           //         developer = new Developer(developers[i], "", 0);
           //         _portalContext.Developers.Add(developer);
           //     }

           //     newGame.AddDeveloper(developer);
           // }

           // for (int i = 0; i < publishers.Length; i++)
           // {
           //     var publisher = await _portalContext.Publishers.Where(pub => pub.Name == publishers[i]).FirstOrDefaultAsync();
           //     if (publisher == null)
           //     {
           //         publisher = new Publisher(publishers[i], "", 0);
           //         _portalContext.Publishers.Add(publisher);
           //     }

           //     newGame.Publishers.Add(publisher);
           // }

           // _portalContext.Games.Add(newGame);

           // await _portalContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

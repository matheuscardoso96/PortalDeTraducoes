using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalDeTraducoes.Context;
using PortalDeTraducoes.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDeTraducoes.Controllers
{
    public class PublishersController : Controller
    {
        private DataContext _portalContexto;
        public PublishersController(DataContext portalContexto)
        {
            _portalContexto = portalContexto;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _portalContexto.Publishers.OrderBy(n => n.Name).ToListAsync());
        }

        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Register([Bind("ID","Name","ImageUrl")]Publisher publisher)
        {
            _portalContexto.Publishers.Add(publisher);
            _portalContexto.SaveChanges();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Page(string publisherName)
        {          
            return View(await _portalContexto.Publishers.Where(p => p.Name.Contains(publisherName)).Include(p => p.Games).FirstOrDefaultAsync());
        }

      
    }
}

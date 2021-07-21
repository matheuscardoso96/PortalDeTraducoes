﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalDeTraducoes.Context;
using PortalDeTraducoes.Models.Entities;
using PortalDeTraducoes.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDeTraducoes.Controllers
{
    public class TranslationsController : Controller
    {
        private readonly DataContext _portalContext;

        public TranslationsController(DataContext portalContext)
        {
            _portalContext = portalContext;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> RegisterNewTranslation(string gameName) 
        {
            var game = await _portalContext.Games
                .Include(g => g.Platforms)
                .Include(g => g.Platforms)
                .Where(g => g.Title == gameName)
                .FirstOrDefaultAsync();

            if (game == null)
                return RedirectToAction("Index", "Games");
            

            ViewBag.Languages = _portalContext.Languages.Select(l => new SelectListItem()
            { Text = l.Name, Value = l.ID.ToString() }).ToList();

            var translationIm = new TranslationInputModel()
            {
                GameName = game.Title,
                GameId = game.ID
            };

            translationIm.Users.Add(User.Identity.Name);
            translationIm.TranslationImages.Add("https://jacutemsabao.bitbucket.io/img/boxart/adp1.png");
            translationIm.TranslationImages.Add("https://jacutemsabao.bitbucket.io/img/boxart/adp4.png");

            return View(translationIm);       
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterNewTranslation(TranslationInputModel translationInput)
        {
            if (ModelState.IsValid)
            {
                Translation translation = new Translation(translationInput.GameId,translationInput.GroupID, 0, translationInput.LanguageID);

                foreach (var user in translationInput.Users)
                    translation.AddUser(await _portalContext.Users.Where(u => u.UserName == user).FirstOrDefaultAsync());

                foreach (var imgUrl in translationInput.TranslationImages)
                    translation.AddImageUrl(new TranslationImage(imgUrl, 0));
               
                    translation.AddTranslationVersion(new TranslationVersion(translationInput.Version,translationInput.DownloadLink, translationInput.PatchNote,0, 0));

                _portalContext.Translations.Add(translation);
                await _portalContext.SaveChangesAsync();

                return RedirectToAction("Game", "Games", new object []{ translationInput.GameName });

            }
            ViewBag.Languages = _portalContext.Languages.Select(l => new SelectListItem()
            { Text = l.Name, Value = l.ID.ToString() }).ToList();

            return View(translationInput);
        }
    }
}

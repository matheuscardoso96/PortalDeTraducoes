using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortalDeTraducoes.Models.Entities;
using PortalDeTraducoes.Models.InputModels;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortalDeTraducoes.Models.ViewModels;
using PortalDeTraducoes.Context;
using Microsoft.EntityFrameworkCore;

namespace PortalDeTraducoes.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly DataContext _portalContext;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, DataContext portalContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _portalContext = portalContext;
        }
       
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index","Home");
            
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login([Bind("NickName", "Password")] UserLoginInputModel userLoginInputModel, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            if (!ModelState.IsValid)
                return RedirectToAction("Login");

             
            var result = await _signInManager.PasswordSignInAsync(userLoginInputModel.NickName, userLoginInputModel.Password,userLoginInputModel.StayLogged,false);

            if (result.Succeeded) 
                return !string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl) ? LocalRedirect(returnUrl) : RedirectToAction("Index", "Home");
                                    

             ModelState.AddModelError("", "Apelido ou senha estão incorretos.");


            return View(userLoginInputModel);
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserInputModel userInputModel)
        {
            if (!ModelState.IsValid)
                return View(userInputModel);
            
            var user = new User { UserName = userInputModel.NickName, Email = userInputModel.Email, Country = userInputModel.Country };
            var result = await _userManager.CreateAsync(user, userInputModel.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Usuário");
                await _signInManager.SignInAsync(user,isPersistent:false);             
                return RedirectToAction("Index","Home");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);
           

            return View(userInputModel);
        }


        [AllowAnonymous]
        [AcceptVerbs("Get","Post")]
        public async Task<JsonResult> CheckEmail(string email) 
        {
        
           if (await _userManager.FindByEmailAsync(email) != null)
              return Json($"E-mail {email} já está em uso.");           
            
            return Json(true);
        }


        public JsonResult GetUsers(string term)
        {
            var users = _portalContext.Users.Where(u => u.UserName.Contains(term)).Select(us => us.UserName);

            return Json(users);
        }

        [AllowAnonymous]
        [AcceptVerbs("Get", "Post")]
        public async Task<JsonResult> CheckNick(string nickName)
        {

            if (await _userManager.FindByNameAsync(nickName) != null)
                return Json($"O apelido {nickName} já está em uso.");

            return Json(true);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
           await _signInManager.SignOutAsync();
           return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Profile() 
        {
            var user = await _userManager.GetUserAsync(User);
            var userTranslations = _portalContext.Translations.Include(t => t.Users.Where(u => u.Id == user.Id));//Where(t => t.Users.Contains(user)).ToList();
            List<string> translations = new List<string>();
            foreach (var translation in userTranslations)
                translations.Add($"{translation.Game.Title}");
            
            var userVm = new UserProfileViewModel() { NickName = user.UserName, Email = user.Email, Country = user.Country, Translations = translations };
            userVm.Group = user.GroupID != null ? user.Group.Name: "";
            return View(userVm);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            
            return View();
        }
    }
}

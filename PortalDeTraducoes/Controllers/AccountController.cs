using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortalDeTraducoes.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDeTraducoes.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
       
        [AllowAnonymous]
        public IActionResult Login()
        {          
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([Bind("NickName", "Password")] UserLoginInputModel userLoginInputModel, string returnUrl)
        {
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
        public async Task<IActionResult> Register([Bind("NickName", "Email", "Password", "ConfirmPassword")] UserInputModel userInputModel)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Login");
            
            var user = new IdentityUser { UserName = userInputModel.NickName, Email = userInputModel.Email };
            var result = await _userManager.CreateAsync(user, userInputModel.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user,isPersistent:false);
                return RedirectToAction("Index","Home");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);
           

            return View(userInputModel);
        }

        [AcceptVerbs("GET","POST")]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUse(string email) 
        {
        
            if (await _userManager.FindByEmailAsync(email) != null)
                return Json($"E-mail {email} já está em uso.");
            
            
            return Json(true);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
           await _signInManager.SignOutAsync();
           return RedirectToAction("Index", "Home");
        }
    }
}

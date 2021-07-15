using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortalDeTraducoes.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDeTraducoes.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager; 
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewRole()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewRole(RoleInputModel roleInputModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(roleInputModel.Role));

                if (result.Succeeded)
                    return RedirectToAction("AllRoles");
                
                else
                    foreach (var idError in result.Errors)
                        ModelState.AddModelError("", idError.Description);                
                
            }
                      
            return View(roleInputModel);
        }

        [HttpGet]
        public IActionResult AllRoles() 
        {
            var roles =  _roleManager.Roles;
            return View(roles);
        }
    }
}

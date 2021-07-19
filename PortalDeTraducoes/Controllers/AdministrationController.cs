using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortalDeTraducoes.Models;
using PortalDeTraducoes.Models.Entities;
using PortalDeTraducoes.Models.InputModels;
using PortalDeTraducoes.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDeTraducoes.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
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

        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if(role == null)
            {
                ViewBag.ErrorMessage = $"Id de papel {id} não encontrado";
                return View("Error", new ErrorViewModel() {  });
            }
            var editRoleInputModel = new EditRoleInputModel { Id = role.Id, Role = role.Name };
            var users = await _userManager.GetUsersInRoleAsync(role.Name);
            editRoleInputModel.Users = users.Select(u => u.UserName).ToList();
            return View(editRoleInputModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleInputModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.Id);
            if (role == null) 
            {
                ViewBag.ErrorMessage = $"Id de papel {model.Id} não encontrado";
                return Redirect("/Shared/Error");
            }

            role.Name = model.Role;
            var result =  await _roleManager.UpdateAsync(role);

            if (result.Succeeded)
                return RedirectToAction("AllRoles");

            foreach (var idError in result.Errors)
                ModelState.AddModelError("",idError.Description);
            
          
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            ViewBag.RoleId = roleId;
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Id de papel {roleId} não encontrado";
                return Redirect("/Shared/Error");
            }

            var model = new List<UsersRoleInputModel>();
            var usersInThisRole = await _userManager.GetUsersInRoleAsync(role.Name);

            foreach (var user in _userManager.Users)
            {
                var userRoleVm = new UsersRoleInputModel
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };

                if (usersInThisRole.Any(u => u.Id == user.Id))
                    userRoleVm.IsSelected = true;               
                else
                    userRoleVm.IsSelected = false;
                
                model.Add(userRoleVm);

            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UsersRoleInputModel> model,string roleId)
        {
            ViewBag.RoleId = roleId;
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Id de papel {roleId} não encontrado";
                return Redirect("/Shared/Error");
            }

            //  var model = new List<UsersRoleInputModel>();


            foreach (var md in model)
            {
                var user = await _userManager.FindByIdAsync(md.UserId);
                IdentityResult result = null;

                if (md.IsSelected && !await _userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await _userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!md.IsSelected && await _userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await _userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }
            }         
          
            

            return RedirectToAction("EditRole", new { Id = roleId });
        }

        [HttpGet]
        public  IActionResult ListUsers()
        {
            var users = _userManager.Users.Where(u => u.Active);
            return View(users);
        }

        [HttpGet]
        public async Task <IActionResult> EditUser(string id)
        {
            var user = await  _userManager.FindByIdAsync(id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"Não foi possível encontrar o usuário com o id {id}";
                return View("Error", new { Id = id });
            }

            var userInput = new EditUserInputModel() { Id = user.Id, NickName = user.UserName , Country = user.Country, Email = user.Email }; 

            return View(userInput);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserInputModel model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("EditUser", new { model.Id });

            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"Não foi possível encontrar o usuário com o id {model.Id}";
                return View("Error", new { model.Id }) ;
            }

            user.UserName = model.NickName;
            user.Email = model.Email;
            user.Country = model.Country;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
                return RedirectToAction("ListUsers");
            

            foreach (var item in result.Errors)
                ModelState.AddModelError("", item.Description);


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DisableUser(string Id)
        {          

            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"Não foi possível encontrar o usuário com o id {Id}";
                return View("Error", new { Id });
            }

            user.Deactivate();

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
                return RedirectToAction("ListUsers");


            foreach (var item in result.Errors)
                ModelState.AddModelError("", item.Description);


            return View();
        }
    }
}

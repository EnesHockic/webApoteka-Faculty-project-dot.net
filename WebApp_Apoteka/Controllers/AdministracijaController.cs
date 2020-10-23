using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebApp_Apoteka.Models;
using WebApp_Apoteka.ViewModels;

namespace WebApp_Apoteka.Controllers
{
    public class AdministracijaController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<AppUser> userManager;

        public AdministracijaController(RoleManager<IdentityRole> role,
                                        UserManager<AppUser> userManager)
        {
            roleManager = role;
            this.userManager = userManager;
        }


        [HttpGet]
        [Authorize(Roles ="Admin")]
        public IActionResult CreateRole()
        {
            return View();
        }

        
        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleVM model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };
                IdentityResult result = await roleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("RolePrikaz", "Administracija");
                }
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }


        public async Task<AppUser> GetCurrentUser()
        {
            //var user = await userManager.GetUserAsync(HttpContext.User);
            var user= await userManager.GetUserAsync(HttpContext.User);
            return user;
        }

        [Authorize(Roles ="Admin")]
        public IActionResult RolePrikaz()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }


        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> UrediUlogu(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Uloga sa ID = {id} nije pronadjenja!";
                return View("NotFound");
            }
            var model = new EditRoleVM
            {
                ID = role.Id,
                RoleName = role.Name,


            };
            foreach (var user in userManager.Users)
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }
            return View(model);
        }


        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> UrediUlogu(EditRoleVM model)
        {
            var role = await roleManager.FindByIdAsync(model.ID);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Uloga sa ID = {model.ID} nije pronadjenja!";
                return View("NotFound");
            }
            else
            {
                role.Name = model.RoleName;
                var result = await roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("roleprikaz");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }
        }


        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddRemoveKorisnikaUlogu(string UlogaID)
        {
            ViewBag.UlogaID = UlogaID;
            var Uloga = await roleManager.FindByIdAsync(UlogaID);
            if (Uloga == null)
            {
                ViewBag.ErrorMessage = $"Uloga sa ID = {UlogaID} nije pronadjena!";
                return View("NotFound");
            }
            ViewBag.NazivUloge = Uloga.Name;
            var model = new List<KorisnikUlogaVM>();
            foreach (var user in userManager.Users)
            {
                if (await userManager.IsInRoleAsync(user, Uloga.Name))
                {

                    var korisnikUlogaVM = new KorisnikUlogaVM
                    {
                        UserID = user.Id,
                        UserName = user.UserName
                    };
                    model.Add(korisnikUlogaVM);
                }
            }
            return View(model);
        }
        [Authorize]
        public async Task<bool> DodijeliUloguFUnction(DodijeliUloguVM model)
        {
            var role = await roleManager.FindByNameAsync(model.nazivUloge);
            if (role == null)
            {
                return false;
            }
            var user = await userManager.FindByIdAsync(model.korisnikID);
            if (user == null)
            {
                return false;
            }
            var result = await userManager.AddToRoleAsync(user, role.Name);
            if (result.Succeeded)
            {
                return true;
                //if (role.Name == "Admin")
                //    return RedirectToAction("AddRemoveKorisnikaUlogu", "Administracija", new { UlogaID = role.Id });
                //else
                //    return RedirectToAction("Index", "Home");
            }
            return false;
        }
        [AllowAnonymous]
        public async Task<IActionResult> DodijeliUlogu(DodijeliUloguVM model)
        {
            var result = await DodijeliUloguFUnction(model);
            
            if (result)
            {
                    return RedirectToAction("Index", "Home");
            }
            ViewBag.ErrorMessage = $"Korisnik sa ID = {model.korisnikID} nije pronadjen!";
            return View("NotFound");

        }
        [Authorize(Roles ="Admin,Korisnik,Apotekar")]
        public async Task<IActionResult> RemoveUserFromRole(string UserId,string RoleId)
        {
            var role = await roleManager.FindByIdAsync(RoleId);
            if(role==null)
            {
                ViewBag.ErrorMessage = $"Uloga nije pronadjen!";
                return View("NotFound");
            }
            var user = await userManager.FindByIdAsync(UserId);
            if(user ==null)
            {
                ViewBag.ErrorMessage = $"Korisnik sa ID = {UserId} nije pronadjen!";
                return View("NotFound");
            }
            if (await userManager.IsInRoleAsync(user,role.Name))
            {
                var result = await userManager.RemoveFromRoleAsync(user, role.Name);
            }

            return RedirectToAction("AddRemoveKorisnikaUlogu", new { UlogaID = RoleId });
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
using EticaretWeb.Identity;
using EticaretWeb.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EticaretWeb.Controllers;

public class AccountController: Controller
{
    private UserManager<ApplicationUser> userManager;
    private RoleManager<ApplicationRole> roleManager;

    public AccountController()
    {
        var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
        userManager = new UserManager<ApplicationUser>(userStore);

        var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
        roleManager = new RoleManager<ApplicationRole>(roleStore);
    }

    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Register(RegisterModel register)
    {
       
        if (ModelState.IsValid)
        {
            var user = new ApplicationUser
            {
                Name = register.Name,
                Surname = register.SurName,
                UserName = register.UserName,
                Email = register.Email
            };

            IdentityResult result = userManager.Create(user, register.Password);

            if (result.Succeeded)
            {
                if (roleManager.RoleExists("user"))
                {
                    userManager.AddToRole(user.Id, "User");
                }

                return RedirectToAction("Login", "Account");

            }
            else
            {
                ModelState.AddModelError("userCreateError", "Kullanıcı Oluşturma Hatası!");
            }
        }
        return View(register);
    }

    public IActionResult Login()
    {
        return View();
    }
}
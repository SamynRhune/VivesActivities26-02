using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VivesActivities.Ui.Mvc.Models;

namespace VivesActivities.Ui.Mvc.Controllers
{
    public class IdentityController(
        SignInManager<IdentityUser> signInManager,
        UserManager<IdentityUser> userManager) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> SignIn()
        {
            await signInManager.SignOutAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(SignInModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = new IdentityUser(model.Username)
            {
                Email = model.Username
            };

            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }

            await signInManager.SignInAsync(user, false);

            return RedirectToAction("Index", "Home");
        }
    }
}

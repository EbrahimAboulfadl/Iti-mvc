using Assignment.Models.Entities;
using Assignment.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Assignment.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Register(RegistraionModel registraionModel)
        {

            if (ModelState.IsValid) {
                ApplicationUser newUser = new ApplicationUser() {
                    UserName = registraionModel.Username,
                    Address = registraionModel.Address,
                    PasswordHash = registraionModel.Password
                };
                var response = await userManager.CreateAsync(newUser, newUser.PasswordHash);
                if (response.Succeeded) {
                    await signInManager.SignInAsync(newUser, false);
                    return RedirectToAction("Index", "Home");
                }

            }
            return View(registraionModel);
        }


        [HttpGet]
        public IActionResult Login() { return View(); }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel userVM) {
            if (ModelState.IsValid) {
                var response = await userManager.FindByNameAsync(userVM.Username);
                if (response != null) {

                    var isPasswordCorrect = await userManager.CheckPasswordAsync(response, userVM.Password);

                    if (isPasswordCorrect)
                    {

                        await signInManager.SignInAsync(response, userVM.IsRememberMe);
                        return RedirectToAction("Index", "Home"); }
                

                }
            }

            ModelState.AddModelError("", "Wrong Username or password");

            return View(userVM);


        }

        [HttpGet]
        public async Task<IActionResult> Logout() { 
        await signInManager.SignOutAsync(); 
        return RedirectToAction("Login", "Account");
        }


    }
}

using Mariala.Areas.Admin.ViewModels;
using Mariala.Entities;
using Mariala.Utilities.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Mariala.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated) return NotFound();
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Register(RegisterVM vm)
        {
            if (!ModelState.IsValid) return View(vm);
            AppUser newUser = new AppUser
            {
                Name = vm.Name,
                Surname = vm.Surname,
                Email = vm.Email,
                UserName = vm.UserName
            };

            var res = await _userManager.CreateAsync(newUser, vm.Password);

            if (!res.Succeeded)
            {
                foreach (var err in res.Errors)
                {
                    ModelState.AddModelError(string.Empty, err.Description);
                }
                return View(vm);
            }
            await _userManager.AddToRoleAsync(newUser, UserRole.Admin.ToString());
            await _signInManager.SignInAsync(newUser, false);
            return RedirectToAction("Index", "Dashboard");
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated) return NotFound();
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Login(LoginVM vm, string? returnUrl = null)
        {
            if (!ModelState.IsValid) return View(vm);

            AppUser user = await _userManager.FindByNameAsync(vm.UserNameOrEmail);
            if (user is null)
            {
                user = await _userManager.FindByEmailAsync(vm.UserNameOrEmail);
                if (user is null) {
                    ModelState.AddModelError(string.Empty, "Username, Email or Password is incorrect!");
                    return View(vm);
                }
            }

            var res = await _signInManager.PasswordSignInAsync(user, vm.Password, vm.IsPersitence, true);
            if (!res.Succeeded)
            {
                if (res.IsLockedOut)
                {
                    ModelState.AddModelError(string.Empty, "Too many attempts, try later!");
                    return View(vm);

                }
                ModelState.AddModelError(string.Empty, "Username, Email or Password is incorrect!");
                return View(vm);
            }
            if (returnUrl is not null) return Redirect(returnUrl);
            return RedirectToAction("Index", "Dashboard");

        }

        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
            }
            return RedirectToAction("Index", "Dashboard");

        }
    }
}

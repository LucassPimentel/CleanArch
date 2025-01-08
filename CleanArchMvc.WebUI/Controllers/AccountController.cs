using CleanArch.Domain.Account;
using CleanArchMvc.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers
{
    public class AccountController : Controller
    {

        private readonly IAuthenticate _authenticate;

        public AccountController(IAuthenticate authenticate)
        {
            _authenticate = authenticate;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            var loginVm = new LoginViewModel() { ReturnUrl = returnUrl };
            return View(loginVm);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVm)
        {
            var result = await _authenticate.AuthenticateAsync(loginVm.Email, loginVm.Password);

            if (result)
            {
                if (string.IsNullOrEmpty(loginVm.ReturnUrl))
                {
                    return RedirectToAction("Index", "Home");
                }

                return Redirect(loginVm.ReturnUrl);
            }
            ModelState.AddModelError(string.Empty, "Não foi possível logar. Tente novamente");
            return View(loginVm);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerVm)
        {
            var result = await _authenticate.RegisterAsync(registerVm.Username, registerVm.Email, registerVm.Password);

            if (result)
            {
                return Redirect("/");
            }
            ModelState.AddModelError(string.Empty, "Não foi possível registrar. Tente novamente");
            return View(registerVm);
        }

        public async Task<IActionResult> Logout()
        {
            await _authenticate.LogoutAsync();
            return Redirect("/Account/Login");
        }
    }
}

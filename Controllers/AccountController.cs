using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SistemaDeCompras.ViewModels;

namespace SistemaDeCompras.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager; 
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (!ModelState.IsValid)
                return View(loginVM);

            //busando o usuário pelo nome
            var user = await _userManager.FindByNameAsync(loginVM.UserName);

             //verificando se o usuário existe no banco de dados
            if (user != null)
            {
                //realizando login
                var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                
                //login com sucesso
                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(loginVM.ReturnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    //erro no login
                    return Redirect(loginVM.ReturnUrl);
                }
            }

            //usuário não existe no banco de dados
            ModelState.AddModelError("", "Falha ao realizar o login!!");
            return View(loginVM);
        }
    }
}

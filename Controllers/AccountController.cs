using System.Net.Http;
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

   //Usuario para teste :

   //User: teste
   //Senha: Teste%y9

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
             //Os pacotes abaixo são necessários para executar os comandos deste método

            //Microsoft.AspNetCore.Identity
            //Microsoft.AspNetCore.Identity.EntityFrameworkCore

            if (!ModelState.IsValid)
                return View(loginVM);

            //buscando o usuário pelo nome
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

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(LoginViewModel registroVM)
        {
            if(ModelState.IsValid){

                //Criando um objeto do tipo IdentityUser, com o nome de usuário que foi enviado no form
                var user=new IdentityUser{UserName=registroVM.UserName};
                //Inserindo no banco de dados, o nome de usuário atribuido ao objeto user e 
                //a senha enviada no form
                var result=await _userManager.CreateAsync(user,registroVM.Password);

                if(result.Succeeded){

                    await _userManager.AddToRoleAsync(user, "Member");
                    return RedirectToAction("Login", "Account");
                }

                else{
                  this.ModelState.AddModelError("Registro", "Falha ao registrar o usuário");
                }
            }

             return View(registroVM);
        }

        [HttpPost]
        public async Task<IActionResult> Logout(){
            HttpContext.Session.Clear(); //Limpando os dados da sessão
            HttpContext.User=null;
            await _signInManager.SignOutAsync(); // Realizando Logout           
            return RedirectToAction("Index", "Home"); 
        }

        public IActionResult AccessDenied(){
            return View();
        }


    }

       
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProvaCadastro.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaCadastro.Controllers
{
    public class AccountController : Controller
    {
      private readonly UserManager<IdentityUser> userManager;

      public AccountController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registro(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var dados = new IdentityUser
                {
                   UserName = registerViewModel.Email,
                   Email = registerViewModel.Email
                };

                var final = await userManager.CreateAsync(dados ,registerViewModel.Password);

                TempData["Message"] = "Cadastrado com sucesso!!";

                return RedirectToAction(nameof(Registro));
            }
            return View(registerViewModel);


            


        }
    }
}

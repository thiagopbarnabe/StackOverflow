using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using StackOverflow.Core.Contexts;

namespace StackOverflow.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly StackOverflowContext _context;

        public AccountController(StackOverflowContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Perguntas");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Models.LoginViewModel model)
        {
            var user = _context.Autores.FirstOrDefault(x => x.Login == model.UserName && x.Senha == model.Password);
            if (user != null)
            {
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, model.UserName));
                claims.Add(new Claim(ClaimTypes.Role, "admin"));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, user.AutorId.ToString()));
                var id = new ClaimsIdentity(claims, "password");
                var principal = new ClaimsPrincipal(id);
                await HttpContext.SignInAsync("app", principal, new AuthenticationProperties() { IsPersistent = model.IsPersistent });

                return RedirectToAction("Index", "Perguntas");
            }
            
            return View();
        }

        public async Task<IActionResult> Logoff()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
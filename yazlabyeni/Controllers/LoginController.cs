using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using DataAccessLayer.Concrete;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace yazlabyeni.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Login(User user)
        {
            var claims = new List<Claim> 
            {
                new Claim(ClaimTypes.Name,"UserSession"),
                new Claim(ClaimTypes.Role,"User")
            };

            var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            var authproperties = new AuthenticationProperties();

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity),authproperties);
            Context context = new Context();

            var userinfo = context.Users.FirstOrDefault(x => x.Mail == user.Mail && x.Password == user.Password);

            if (userinfo != null)
            {
                HttpContext.Session.SetString("Mail", user.Mail);
                return RedirectToAction("Index", "User");
            }
            
            return View();
        }  

        [HttpGet]
        public IActionResult TrainerLogin()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> TrainerLogin(Trainer trainer)
        {
            var claims = new List<Claim> 
            {
                new Claim(ClaimTypes.Name,"TrainerSession"),
                new Claim(ClaimTypes.Role,"Trainer")
            };

            var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            var authproperties = new AuthenticationProperties();

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity),authproperties);
            Context context = new Context();

            var userinfo = context.Trainers.FirstOrDefault(x => x.Mail == trainer.Mail && x.Password == trainer.Password);

            if (userinfo != null)
            {
                HttpContext.Session.SetString("Mail", trainer.Mail);
                return RedirectToAction("Index", "Trainer");
            }
            
            return View();
        }

        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> AdminLogin(Admin admin)
        {
            var claims = new List<Claim> 
            {
                new Claim(ClaimTypes.Name,"AdminSession"),
                new Claim(ClaimTypes.Role,"Admin")
            };

            var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            var authproperties = new AuthenticationProperties();

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity),authproperties);
            Context context = new Context();

            var userinfo = context.Admins.FirstOrDefault(x => x.Name == admin.Name && x.Password == admin.Password);

            if (userinfo != null)
            {
                HttpContext.Session.SetString("Name", admin.Name);
                return RedirectToAction("Index", "Home");
            }
            
            return View();
        }


    }
}

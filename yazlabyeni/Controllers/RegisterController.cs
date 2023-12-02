using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace yazlabyeni.Controllers
{
    public class RegisterController : Controller
    {
        UserManager UserManager = new UserManager();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetRegister(User user)
        {
            UserManager.InsertUser(user);
            return RedirectToAction("Login","Login");
        }
    }
}

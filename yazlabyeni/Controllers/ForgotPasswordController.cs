using Microsoft.AspNetCore.Mvc;

namespace yazlabyeni.Controllers
{
    public class ForgotPasswordController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

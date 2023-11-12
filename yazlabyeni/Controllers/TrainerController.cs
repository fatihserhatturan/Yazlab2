using Microsoft.AspNetCore.Mvc;

namespace yazlabyeni.Controllers
{
    public class TrainerController : Controller
    {
        public IActionResult TrainerPage(int trainerId)
        {
            return View(trainerId);
        }
    }
}

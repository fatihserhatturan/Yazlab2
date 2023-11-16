using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace yazlabyeni.Controllers
{
    public class TrainerController : Controller
    {
        public IActionResult TrainerPage(int trainerId)
        {
            return View(trainerId);
        }
        
        [HttpGet]
        public IActionResult Update(Trainer trainer)
        {
            //Güncelleme ile ilgili istenen değişiklilkleri burda yapabailirsin totoş
            TrainerManager trainerManager = new TrainerManager();
            trainerManager.Update(trainer);
            return View(trainer.TrainerId);
        }

    }
}

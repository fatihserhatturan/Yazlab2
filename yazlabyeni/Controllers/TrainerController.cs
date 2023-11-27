using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace yazlabyeni.Controllers
{
    public class TrainerController : Controller
    {
        TrainerManager trainerManager = new TrainerManager();
        UserManager userManager = new UserManager();
        UserTrainerManager UserTrainerManager = new UserTrainerManager();
        public IActionResult TrainerPage(int trainerId)
        {
            return View(trainerId);
        }
        
        [HttpGet]
        public IActionResult Update(Trainer trainer)
        {
            //Güncelleme ile ilgili istenen değişiklilkleri burda yapabailirsin totoş
            
            trainerManager.Update(trainer);
            return View(trainer.TrainerId);
        }

        [Authorize(Roles =("User,Admin,Trainer"))]
        [HttpPost]
        public IActionResult UserApplication(int id)
        {
            string  getUser = HttpContext.Session.GetString("UserMail");
            User user = userManager.GetUserByEmail(getUser);

            UserTrainer userTrainer = new UserTrainer
            {
                TrainerID = id,
                UserID = user.UserId

            };

            UserTrainerManager.InsertUserTrainer(userTrainer);

            return RedirectToAction("TrainerPage");
        }

    }
}

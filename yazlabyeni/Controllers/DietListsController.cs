using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace yazlabyeni.Controllers
{
    public class DietListsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ListDiet()
        {
            DietListsManager dietListsManager = new DietListsManager();
            List<DietList> dietLists = new List<DietList>();
            return View(dietListsManager);
        }
        public IActionResult Update(DietList dietList)
        {
            DietListsManager dietListsManager = new DietListsManager();
            dietListsManager.Update(dietList);
            return View(dietListsManager);
        }
        public void AssignDiet(int UserId,int DietListId)
        {
            DietManager dietManager = new DietManager();
            TrainerManager tm = new TrainerManager();
            var p = HttpContext.Session.GetString("AuthorMail");
            Trainer trainer = tm.GetTrainerByEmail(p);
            Diet diet = new Diet()
            {
                UserId = UserId,
                TrainerId = trainer.TrainerId,
                DietListId = DietListId,
            };
            dietManager.AddDiet(diet);
        }

    }
}

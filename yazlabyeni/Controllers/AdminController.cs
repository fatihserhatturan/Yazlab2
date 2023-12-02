using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace yazlabyeni.Controllers
{
    public class AdminController : Controller
    {
        UserManager userManager = new UserManager();
        TrainerManager trainerManager = new TrainerManager();
        ExercisesListsManager ExercisesListsManager = new ExercisesListsManager();
        DietListsManager DietListsManager = new DietListsManager();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserList()
        {
            var userlist = userManager.GetAllUsers();
            return View(userlist);
        }
        public IActionResult ToggleStatus(int userId)
        {
            try
            {
                userManager.ToggleUserStatus(userId);
                TempData["Message"] = "Durum başarıyla değiştirildi.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Hata: {ex.Message}";
            }

            return RedirectToAction("UserList");
        }

        public IActionResult TrainerList()
        {
            var trainerlist = trainerManager.GetAllTrainer();
            return View(trainerlist);
        }
        public IActionResult ToggleStatusTrainer(int userId)
        {
            try
            {
                trainerManager.ToggleTrainerStatus(userId);
                TempData["Message"] = "Durum başarıyla değiştirildi.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Hata: {ex.Message}";
            }

            return RedirectToAction("TrainerList");
        }

        public IActionResult ExerciseList()
        {
           var exerciselist = ExercisesListsManager.GetAllExercises();
            return View(exerciselist);
        }

        public IActionResult DietList()
        {

            var dietList = DietListsManager.GetAllLists();
            return View(dietList);

        }
        public IActionResult AddExercise()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddExercise(ExerciseList exerciseList)
        {
            ExercisesListsManager.InsertExercise(exerciseList);
            return RedirectToAction("AddExercise");
        }

        public IActionResult AddDiet()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDiet(DietList dietList)
        {
           DietListsManager.Insert(dietList);
            return RedirectToAction("AddDiet");
        }

        public IActionResult GetExercise(int Id)
        {
            ExerciseList ex =ExercisesListsManager.GetExerciseByID(Id);
            return View(ex);
        }

        public IActionResult UpdateExercise(ExerciseList exerciseList)
        {
            ExercisesListsManager.Update(exerciseList);
            return RedirectToAction("ExerciseList");
        }
        public IActionResult GetDiet(int Id)
        {
            DietList dt = DietListsManager.GetDietListByID(Id);
            return View(dt);
        }

        public IActionResult UpdateDiet(DietList dietList)
        {
            DietListsManager.Update(dietList);
            return RedirectToAction("DietList");
        }
    }
}

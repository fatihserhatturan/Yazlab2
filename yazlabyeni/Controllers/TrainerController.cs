﻿
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using yazlabyeni.Models;

namespace yazlabyeni.Controllers
{
    public class TrainerController : Controller
    {
        TrainerManager trainerManager = new TrainerManager();
        UserManager userManager = new UserManager();
        UserTrainerManager UserTrainerManager = new UserTrainerManager(new EfUserTrainerRepository());
        DietManager DietManager = new DietManager();
        DietListsManager DietListsManager = new DietListsManager();
        ExercisesListsManager ExercisesListsManager = new ExercisesListsManager();
        TrainerDietManager trainerDietManager = new TrainerDietManager(new EfTrainerDietRepository());
        TrainerExerciseManager TrainerExerciseManager = new TrainerExerciseManager(new EfTrainerExerciseRepository());
       
        public IActionResult Index()
        {
            var p = HttpContext.Session.GetString("Mail");
            Trainer trainer = trainerManager.GetTrainerByEmail(p);

            return View(trainer);
        }

        [HttpPost]
        public IActionResult TrainerProfileInfoUpdate(Trainer trainer)
        {
            trainerManager.Update(trainer);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddImage(AddTrainerPhoto p)
        {
            var A = HttpContext.Session.GetString("Mail");
            Trainer u = trainerManager.GetTrainerByEmail(A);
            if (p.TrainerPhoto != null)
            {
                var extensions = Path.GetExtension(p.TrainerPhoto.FileName);
                var newImageName = Guid.NewGuid() + extensions;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                p.TrainerPhoto.CopyTo(stream);
                u.TrainerPhoto = newImageName;

            }

            trainerManager.Update(u);
            return RedirectToAction("Index");

        }
      

        public IActionResult TrainerDefaultDiets()
        {
            Trainer trainer = trainerManager.GetTrainerByEmail(HttpContext.Session.GetString("Mail"));
            var includeDiets = trainerDietManager.GetDietByTrainer(trainer.TrainerId);
            var allDiets = DietListsManager.GetAllLists();

            var dietViewModels = new List<DietViewModel>();

            foreach (var diet in allDiets)
            {
                var dietViewModel = new DietViewModel
                {
                    DietView = diet,
                    IsInclude =includeDiets.Any(d=>d.DietList.DietListId == diet.DietListId && d.Status == true)
                };

                dietViewModels.Add(dietViewModel);
            }

            Console.WriteLine(dietViewModels.Count);

            return View(dietViewModels);
        }

        public IActionResult TrainerDefaultExercises()
        {
            Trainer trainer = trainerManager.GetTrainerByEmail(HttpContext.Session.GetString("Mail"));
            var includeExercises = TrainerExerciseManager.GetTrainerExerciseById(trainer.TrainerId);
            var allExercise = ExercisesListsManager.GetAllExercises();

            var exerciseViewModels = new List<ExerciseViewModel>();

            foreach (var exercise in allExercise)
            {
                var exerciseViewModel = new ExerciseViewModel
                {
                    ExerciseList = exercise,
                    IsIncluded = includeExercises.Any(d=>d.ExerciseList.ExerciseListId == exercise.ExerciseListId && d.Status == true)
                };

                exerciseViewModels.Add(exerciseViewModel);
            }

            return View(exerciseViewModels);
        }
        public IActionResult ExerciseStatusTrue(int Id)
        {
            Trainer trainer = trainerManager.GetTrainerByEmail(HttpContext.Session.GetString("Mail"));
            TrainerExerciseManager.InsertExercise(trainer.TrainerId, Id);
            return RedirectToAction("TrainerDefaultExercises");
        }

        public IActionResult ExerciseStatusFalse(int Id)
        {
            Trainer trainer = trainerManager.GetTrainerByEmail(HttpContext.Session.GetString("Mail"));
            TrainerExerciseManager.DeleteExercise(trainer.TrainerId, Id);
            return RedirectToAction("TrainerDefaultExercises");
        }
        public IActionResult DietStatusTrue(int Id)
        {
            Trainer trainer = trainerManager.GetTrainerByEmail(HttpContext.Session.GetString("Mail"));
            trainerDietManager.InsertDiet(trainer.TrainerId, Id);
            return RedirectToAction("TrainerDefaultDiets");
        }

        public IActionResult DietStatusFalse(int Id)
        {
            Trainer trainer = trainerManager.GetTrainerByEmail(HttpContext.Session.GetString("Mail"));
            trainerDietManager.DeleteDiet(trainer.TrainerId, Id);
            return RedirectToAction("TrainerDefaultDiets");
        }

        public IActionResult TrainerUserApplication()
        {
            Trainer trainer = trainerManager.GetTrainerByEmail(HttpContext.Session.GetString("Mail"));
            var appliedUserList = UserTrainerManager.GetUserTrainersByTrainerId(trainer.TrainerId);

            return View(appliedUserList);
        }

        public IActionResult UserApplicationStatusTrue(int Id)
        {
            UserTrainerManager.StatusChangeTrue(Id);

            return RedirectToAction("TrainerUserApplication");
        }
        public IActionResult UserApplicationStatusFalse(int Id)
        {
            UserTrainerManager.StatusChangeFalse(Id);

            return RedirectToAction("TrainerUserApplication");
        }

        [Authorize(Roles =("User,Admin,Trainer"))]
        [HttpPost]
        public IActionResult UserApplication(int id)
        {
            string  getUser = HttpContext.Session.GetString("Mail");
            User user = userManager.GetUserByEmail(getUser);

            UserTrainer userTrainer = new UserTrainer
            {
                TrainerID = id,
                UserID = user.UserId

            };

            UserTrainerManager.InsertUserTrainer(userTrainer);

            return RedirectToAction("TrainerPage", new { trainerId = id });
        }

        public IActionResult TrainerPage(int trainerId)
        {
            return View(trainerId);
        }
    }
}

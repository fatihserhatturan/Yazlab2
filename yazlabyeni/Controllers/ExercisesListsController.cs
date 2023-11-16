using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace yazlabyeni.Controllers
{
    public class ExercisesListsController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult List()
        {
            ExercisesListsManager exercisesListsManager = new ExercisesListsManager();
            List<ExerciseList> exerciseLists = exercisesListsManager.GetAllExercises();
            return View(exerciseLists);
        }
        
        public  IActionResult Update(ExerciseList exerciseList)
        {
            ExercisesListsManager exercisesListsManager = new ExercisesListsManager();
            exercisesListsManager.Update(exerciseList);
            return View(exerciseList);
        }
        public void AssignExercise(int UserId,int ExerciseListId,DateTime ExerciseDate)
        {
            ExerciseManager exerciseManager = new ExerciseManager();
            var p = HttpContext.Session.GetString("AuthorMail");
            TrainerManager tm = new TrainerManager();
            Trainer trainer = tm.GetTrainerByEmail(p);
            
            Exercise exercise = new Exercise()
            {
                UserId=UserId,
                TrainerId=trainer.TrainerId,
                ExerciseListId=ExerciseListId,
                ExerciseDate=ExerciseDate,
            };
            exerciseManager.AddExercise(exercise);
           
        }

    }
}

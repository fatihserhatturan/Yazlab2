﻿using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using yazlabyeni.Models;

namespace yazlabyeni.Controllers
{
    [Authorize(Roles ="User")]
    public class UserController : Controller
    {
		UserManager userManager = new UserManager();
        UserInfosManager userInfosManager = new UserInfosManager();
        ExerciseManager exerciseManager = new ExerciseManager();
        ExercisesListsManager exercisesListsManager = new ExercisesListsManager();
        DietManager dietManager = new DietManager();
        DietListsManager dietListsManager = new DietListsManager();

		public IActionResult Index()
        {
			var p = HttpContext.Session.GetString("Mail");
            User user = userManager.GetUserByEmail(p);
            UserInfo userinfo = userInfosManager.GetUserInfoById(user.UserId);

			return View(userinfo);
        }

        public IActionResult UserProfile()
        {
			var p = HttpContext.Session.GetString("Mail");
			User user = userManager.GetUserByEmail(p);
			return View(user);
        }

        [HttpPost]
        public IActionResult UserProfileInfoUpdate(User user)
        {
            userManager.Update(user);
            return RedirectToAction("UserProfile");
        }

        public IActionResult UserDiet()
        {
            var p = HttpContext.Session.GetString("Mail");
            User user = userManager.GetUserByEmail(p);
            Diet diet = dietManager.GetDietsByUserId(user.UserId);
            DietList dietList = dietListsManager.GetDietListByID(diet.DietListId);
            return View(dietList);
        }

        public IActionResult UserExercise()
        {
            var p = HttpContext.Session.GetString("Mail");
            User user = userManager.GetUserByEmail(p);
            Exercise exercise = exerciseManager.GetExercisesByUserId(user.UserId);
            ExerciseList exerciseList = exercisesListsManager.GetExerciseByID(exercise.ExerciseListId);

            return View(exerciseList);
        }

        [HttpPost]
        public IActionResult AddImage(AddUserPhoto p)
        {
            var A = HttpContext.Session.GetString("Mail");
            User u = userManager.GetUserByEmail(A);
            if (p.PhotoUrl != null)
            {
                var extensions = Path.GetExtension(p.PhotoUrl.FileName);
                var newImageName = Guid.NewGuid() + extensions;
                var location = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/Images/",newImageName);
                var stream = new FileStream(location, FileMode.Create);
                p.PhotoUrl.CopyTo(stream);
                u.PhotoUrl = newImageName;

            }

            userManager.Update(u);
            return RedirectToAction("UserProfile");

        }

        public IActionResult UserMessages()
        {
            return View();
        }

        public IActionResult ListUSers() 
        {
            UserManager userManager = new UserManager();
            List<User> users = new List<User>();
            return View(users);
        }
        public IActionResult Update(User user) 
        {
            UserManager userManager = new UserManager();
            userManager.Update(user);
            return View(user.UserId);
        }
        public IActionResult ListUsersByTrainerId() 
        {
            UserManager userManager= new UserManager();
            TrainerManager tm = new TrainerManager();
            var p = HttpContext.Session.GetString("AuthorMail");
            Trainer trainer = tm.GetTrainerByEmail(p);
            List<User> users = userManager.GetUsersByTrainerId(trainer.TrainerId);
            return View(users);
        }
        public IActionResult ShowUserInfosByUserId(int id)
        {
            UserInfosManager uIM = new UserInfosManager();
            //UserManager um = new UserManager();
            //var p = HttpContext.Session.GetString("AuthorMail");
            //User user = um.GetUserByEmail(p);
            return View(uIM.GetUserInfoByUserID(id));
        }
        public IActionResult UpdateUserInfo()
        {
            UserInfosManager userInfosManager = new UserInfosManager();
            
            UserManager um = new UserManager();
            var p = HttpContext.Session.GetString("AuthorMail");
            User user = um.GetUserByEmail(p);
            UserInfo userInfo = userInfosManager.GetUserInfoByUserID(user.UserId);
            userInfosManager.Update(userInfo);
            return View(userInfo);
        }
    }
}

using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace yazlabyeni.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
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

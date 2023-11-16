using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    
    public class UserManager
    {
        IUserDal userDal;
        Repository<User> repository = new Repository<User>();

        public List<User> GetAllUsers()
        {
            return repository.List().ToList();
        }
        public User GetUSerById(int id)
        {
            User user = repository.Find(x=>x.UserId == id);
            return user;
        }
        
        public int Update(User user)
        {
            return repository.Update(user);
        }
        public List<User> GetUsersByTrainerId(int id) 
        {
            UserManager um = new UserManager();
            UserTrainerManager userTrainerManager = new UserTrainerManager();
            List<UserTrainer> userTrainers = userTrainerManager.GetUserTrainersByTrainerId(id);
            List<User> users = new List<User>();
            foreach (UserTrainer ut in userTrainers)
            {
                users.Add(um.GetUSerById(ut.UserID));
            }
            return users;
        }
        public User GetUserByEmail(string email)
        {
            return repository.Find(x => x.Mail==email);
        }
    }
}

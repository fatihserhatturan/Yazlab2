using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class UserTrainerManager
    {
        IUserTrainerDal UserTrainerDal;
        Repository<UserTrainer> repository = new Repository<UserTrainer>();
        public List<UserTrainer> GetUserTrainersByTrainerId(int id)
        {
            return  UserTrainerDal.GetAll().Where(x=>x.TrainerID==id).ToList();
        }

        public int InsertUserTrainer(UserTrainer userTrainer)
        {
            return UserTrainerDal.Insert(userTrainer);
        }
    }
}

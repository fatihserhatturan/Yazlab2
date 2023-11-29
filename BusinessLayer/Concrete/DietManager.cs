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
    public class DietManager
    {
        Repository<Diet> repository= new Repository<Diet>();
        IDietDal dietDal;
        public List<Diet> GetDiets()
        {
            return repository.List().ToList();
        }
        public Diet GetDietById(int id)
        {
            Diet diet = repository.GetById(id);
            return diet;
        }
        public Diet GetDietByDietListID(int dietListID)
        {
            Diet diet = repository.Find(x=>x.DietListId == dietListID);
            return diet;
        }
        public List<Diet> GetDietsByTrainerId(int trainerId)
        {
            return dietDal.GetAll().Where(x=>x.TrainerId == trainerId).ToList();
        }
        public Diet GetDietsByUserId(int userId)
        {
            return repository.Find(x=> x.UserId == userId);
        }
        public int AddDiet(Diet diet)
        {
            return dietDal.Insert(diet);
        }
    }
}

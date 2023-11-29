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
    public class ExerciseManager
    {
        Repository<Exercise> repository= new Repository<Exercise>();
        IExerciseDal ExerciseDal;
        public List<Exercise> GetExercises()
        {
            return repository.List().ToList();
        }
        public Exercise GetExerciseById(int id)
        {
            Exercise exercise = repository.GetById(id);
            return exercise;
        }
        public Exercise GetExerciseByExercisesListsId(int id)
        {
            Exercise exercise = repository.Find(x=>x.ExerciseListId==id);
            return exercise;
        }
        public List<Exercise>  GetExercisesByTrainerId(int trainerId)
        {
           return ExerciseDal.GetAll().Where(x=>x.TrainerId == trainerId).ToList();

        }
        public Exercise GetExercisesByUserId(int userId)
        {
            return repository.Find(x=>x.UserId == userId);
        }
        public int AddExercise(Exercise exercise)
        {
            
            return ExerciseDal.Insert(exercise);
        }
        
    }
}

﻿using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ExercisesListsManager
    {
        Repository<ExerciseList> repository = new Repository<ExerciseList>();

        public List<ExerciseList> GetAllExercises()
        {
            return repository.List().ToList();
        }
        public ExerciseList GetExerciseByID(int id)
        {
            ExerciseList exerciseList = repository.Find(x=>x.ExerciseListId == id);
            return exerciseList;
        }
        public int Update(ExerciseList exerciseList)
        {
            return repository.Update(exerciseList);
        }
    }
}

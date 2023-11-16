using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TrainerManager
    {
        Repository<Trainer> repository= new Repository<Trainer>();

        public List<Trainer> GetAllTrainer()
        {
            return repository.List().ToList();
        }

        public Trainer GetTrainerById(int Id) 
        {
            Trainer trainer = repository.Find(x=>x.TrainerId == Id);
            return trainer;
        }
        public int Update(Trainer trainer)
        {
            return repository.Update(trainer);
        }
        public Trainer GetTrainerByEmail(string Email)
        {
            return repository.Find(x=>x.Mail == Email);
        }
    }
}

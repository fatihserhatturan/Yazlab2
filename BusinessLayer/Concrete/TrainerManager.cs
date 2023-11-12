﻿using DataAccessLayer.Concrete;
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
    }
}
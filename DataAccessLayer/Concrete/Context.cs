﻿using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=MUSTI\\SQLEXPRESS;database=Yazlab2.3;Integrated Security=True;");
        }

       public DbSet<Admin>? Admins { get; set; }

       public DbSet<Trainer>? Trainers { get; set; }

       public  DbSet<User>? Users { get; set; }

       public DbSet<Diet>? Diets { get; set;}

       public DbSet<DietList>? DietLists { get; set; }

       public DbSet<Exercise>? Exercises { get; set;}

       public DbSet<ExerciseList>? ExercisesLists { get; set;}

       public DbSet<Message>? Messages { get; set; }

       public DbSet<UserInfo>? UserInfos { get; set; }

       public DbSet<UserTrainer>? UserTrainers { get; set;}        
    }
}

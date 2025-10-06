using GymDataAccsess.Data;
using GymDataAccsess.Models;
using GymDataAccsess.Repositres.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDataAccsess.Repositres.Classes
{
    internal class TrainerRepositry : ITrainerRepositry
    {
        private readonly GymDbContext dbContext;

        public TrainerRepositry(GymDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public int Add(Member member)
        {
            dbContext.Members.Add(member);
            return dbContext.SaveChanges(); 
        }

        public int Delete(Trainer trainer)
        {
            dbContext.trainers.Remove(trainer);
           return dbContext.SaveChanges();
        }

        public IEnumerable<Trainer> GetAll()
        {
           return dbContext.trainers.ToList();
        }

        public Trainer? GetById(int id)
        {
            return dbContext.trainers.Find(id);
        }

        public int Update(Trainer trainer)
        {
            dbContext.trainers.Update(trainer);

            return dbContext.SaveChanges();
        }
    }
}

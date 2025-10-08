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
    public class PlanRepositry : IPlanRepositry
    {
        private readonly GymDbContext dbContext;

        public PlanRepositry(GymDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<Plan> GetAll()
        {
            return dbContext.Plans.ToList();
        }

        public Plan? getById(int id)
        {
            return dbContext.Plans.Find(id);
        }

        public int update(Plan session)
        {
            dbContext.Plans.Update(session);    
            return dbContext.SaveChanges();
        }
    }
}

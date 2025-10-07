using GymDataAccsess.Data;
using GymDataAccsess.Models;
using GymDataAccsess.Repositres.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDataAccsess.Repositres.Classes
{
    internal class GenaricRpositry<TModel> : IRepositryGenaric<TModel> where TModel : BaseEntities, new()
    {
        private readonly GymDbContext dbContext;

        public GenaricRpositry(GymDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public int Add(TModel model)
        {
            dbContext.Set<TModel>().Add(model); 
            return dbContext.SaveChanges();
        }

        public int Delete(TModel model)
        {
            dbContext.Set<TModel>().Remove(model);
            return dbContext.SaveChanges();
        }

        public TModel? GetById(int id) => dbContext.Set<TModel>().Find(id);
               
        

        public IEnumerable<TModel> GetAll() =>dbContext.Set<TModel>().AsNoTracking().ToList();
      

        public int Update(TModel model)
        {

           dbContext.Set<TModel>().Update(model);
            return dbContext.SaveChanges();
        }
    }
}

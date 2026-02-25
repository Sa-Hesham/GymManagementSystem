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
    public class GenaricRpositry<TModel> : IRepositryGenaric<TModel> where TModel : BaseEntities, new()
    {
        private readonly GymDbContext dbContext;

        public GenaricRpositry(GymDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Add(TModel model)=> dbContext.Set<TModel>().Add(model); 
        
        

        public void Delete(TModel model)=> dbContext.Set<TModel>().Remove(model);
           
        

        public IEnumerable<TModel> GetAll(Func<TModel, bool>? condition = null)
        {
            
            if (condition == null)
            {
                return dbContext.Set<TModel>().AsNoTracking().ToList();
            }
            else
            {
                return dbContext.Set<TModel>().AsNoTracking().Where(condition).ToList();
            }
        }

        public TModel? GetById(int id) => dbContext.Set<TModel>().Find(id);
             
      

        public void Update(TModel model)=> dbContext.Set<TModel>().Update(model);
          
        
    }
}

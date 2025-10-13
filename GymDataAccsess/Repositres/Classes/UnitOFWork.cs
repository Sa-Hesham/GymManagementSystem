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
    public class UnitOFWork : IUnitOfWork
    {
        private readonly GymDbContext dbContext;
        private readonly Dictionary<string, object> repositry = new();

        public UnitOFWork(GymDbContext dbContext ,ISessionRepositry sessionRepositry)
        {
            this.dbContext = dbContext;
            SessionRepositry=sessionRepositry;
        }

        public ISessionRepositry SessionRepositry { get; }

        public IRepositryGenaric<TEntity> GetRepositry<TEntity>() where TEntity : BaseEntities, new()
        {
            var keyName = typeof(TEntity).Name;
            if (repositry.TryGetValue(keyName, out object? value))
                return (IRepositryGenaric<TEntity>)value;


           var newrepositry = new GenaricRpositry<TEntity>(dbContext);
           repositry.Add(keyName, newrepositry);
            return newrepositry;
        }
        public int saveCahnges()
        {
           return dbContext.SaveChanges();  
        }
    }
}

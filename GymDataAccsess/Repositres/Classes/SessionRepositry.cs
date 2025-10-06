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
    public class SessionRepositry : ISessionRepositry
    {
        private readonly GymDbContext _dbContext;

        public SessionRepositry(GymDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public int add(Sessions session)
        {
            _dbContext.sessions.Add(session);
            return _dbContext.SaveChanges();
        }

        public int delete(Sessions session)
        {
            _dbContext.sessions.Remove(session);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<Sessions> GetAll()
        {
          return _dbContext.sessions.ToList();
        }

        public Sessions ?getById(int id)
        {
           return _dbContext.sessions.Find(id); 
        }

        public int update(Sessions session)
        {
           _dbContext.sessions.Update(session); 
            return _dbContext.SaveChanges();
        }
    }
}

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
    public class SessionRepositry : GenaricRpositry<Sessions>, ISessionRepositry
    {
        private readonly GymDbContext _dbContext;

        public SessionRepositry(GymDbContext dbContext ):base(dbContext)  
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Sessions> GetAllSessionsWithTrainerAndCategory()
        {
            return _dbContext.sessions.Include(x => x.TrainerSession)
                                       .Include(x => x.SessionCategory)
                                       .ToList();
        }

        public int GetCountOfBookedSlots(int id)
        {
            return _dbContext.membersBookingSessions.Count(x=>x.SessionId==id);
        }

        public Sessions? GetSessionWithTrainerAndCategory(int id)
        {
          return _dbContext.sessions.Include(x=>x.TrainerSession)
                                .Include(x=>x.SessionCategory)
                                .FirstOrDefault(s=>s.Id==id);   
        }
    }
}

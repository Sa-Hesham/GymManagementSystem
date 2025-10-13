using GymDataAccsess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDataAccsess.Repositres.Interfaces
{
    public interface ISessionRepositry :IRepositryGenaric<Sessions>
    {
        IEnumerable<Sessions> GetAllSessionsWithTrainerAndCategory();


        int GetCountOfBookedSlots(int id);



        Sessions ? GetSessionWithTrainerAndCategory(int id);    
    }
}

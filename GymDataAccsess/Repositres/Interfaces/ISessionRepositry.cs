using GymDataAccsess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDataAccsess.Repositres.Interfaces
{
   public interface ISessionRepositry
    {
        Sessions ? getById(int id);

        int update(Sessions session);
        IEnumerable<Sessions> GetAll();

        int add(Sessions session);
        
        int delete(Sessions session);
    }
}

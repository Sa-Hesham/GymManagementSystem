using GymDataAccsess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDataAccsess.Repositres.Interfaces
{
    public interface IPlanRepositry
    {
        Plan? getById(int id);

        int update(Plan session);
        IEnumerable<Plan> GetAll();
    }
}

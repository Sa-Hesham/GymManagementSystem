using GymDataAccsess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDataAccsess.Repositres.Interfaces
{
   internal  interface ITrainerRepositry
    {
        IEnumerable<Trainer> GetAll();

        Trainer ? GetById(int id);  

        int Update (Trainer trainer);

        int Add(Member member);


        int Delete(Trainer trainer );  
    }
}

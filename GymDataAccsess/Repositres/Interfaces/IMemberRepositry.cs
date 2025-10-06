using GymDataAccsess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDataAccsess.Repositres.Interfaces
{
    internal interface IMemberRepositry
    {
        IEnumerable<Member> getAll();

        Member ? GetById(int id);

        int Add(Member member);


        int Update(Member member);


        int Delete( int id );
      
    }
}

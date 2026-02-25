using GymDataAccsess.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDataAccsess.Models
{
    public class Trainer :GymUser
    {

        //HireDateCreatedAtBaseOFEntity

        public Specialites Specialies { get; set; }    



        public ICollection<Sessions>Sessions { get; set; }=new LinkedList<Sessions>();

    }
}

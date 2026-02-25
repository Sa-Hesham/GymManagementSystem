using GymDataAccsess.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace GymDataAccsess.Models
{
    public  abstract class GymUser:BaseEntities
    {

        
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
   
        public DateOnly DateOfBirth { get; set; } 


        public Gendar Gendar { get; set; }

     
        public Address Address { get; set; } =null!;    


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDataAccsess.Models
{
    public class HealthRecord :BaseEntities
    {

        public decimal Height {  get; set; }

        public decimal Weight { get; set; }


        string BloodType { get; set; } = null!;



        public string ? Notes { get; set; } 


    }
}

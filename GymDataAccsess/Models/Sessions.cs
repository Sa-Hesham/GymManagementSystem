using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDataAccsess.Models
{
    internal class Sessions :BaseEntities
    {
        public string Description { get; set; } = null!;

        public int Capcity { get; set; }



        public DateTime StartDate {  get; set; }

        public DateTime EndDate { get; set; } 



    }
}

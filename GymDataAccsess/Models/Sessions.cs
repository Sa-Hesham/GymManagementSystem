using Microsoft.Identity.Client;
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



        public int CategoryId { get; set; }
        public Category SessionCategory { get; set; } = null!;     



        public int TrainerId { get; set; }  

        public Trainer TrainerSession { get; set; }=null!;



        public ICollection<MembersBookingSessions> BookingSessions { get; set; } = new List<MembersBookingSessions>();


    }
}

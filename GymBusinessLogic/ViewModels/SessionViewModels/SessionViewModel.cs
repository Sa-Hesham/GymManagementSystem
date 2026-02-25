using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBusinessLogic.ViewModels.SessionViewModels
{
    public  class SessionViewModel
    {
        public int Id {  get; set; }
        public string CategoryName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string TrainerName { get; set; } = null!;
        
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; } 

        public int Capcity { get; set; }   

        public int AvilableSlots { get; set; }



        #region ComputedProperties

        public string DateDisplay => $"{StartDate:MMM dd yyyy}";

        public string TimeRangeDisplay=> $"{StartDate :hh:mm tt} - {EndDate :hh:mm tt}";

        public TimeSpan Duraration => EndDate- StartDate;


        public string status
        {
            get {

                if (StartDate > DateTime.Now)
                    return "UpComing";
                else if (StartDate <= DateTime.Now && EndDate >= DateTime.Now)
                    return "Ongoing";
                else
                    return "Completed";

                
            
            }
        }
        #endregion


    }
}

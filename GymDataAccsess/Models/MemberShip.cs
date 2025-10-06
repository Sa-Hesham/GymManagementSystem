using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDataAccsess.Models
{
    public class MemberShip :BaseEntities
    {

        //startDate = createdAt of BaseEntities

        public DateTime EndDate { get; set; }

        public string Status {

            get
            {
                if (EndDate <= DateTime.Now)
                    return "Expired";
                else
                    return "Ative";
            }
            

            } 
        public int MemberId { get; set; }
        public Member Member { get; set; } = null!;




        public int PlanId { get; set; }
        public Plan Plan { get; set; } =null!;






    }
}

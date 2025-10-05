using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace GymDataAccsess.Models
{
    internal class Member :GymUser
    {
        string  ? Photo {  get; set; }

        //joinDate = CreatedDate of BaseEnitites


        public HealthRecord HealthRecord { get; set; } = null!;


        public ICollection<MemberShip> memberPlans { get; set; } = new List<MemberShip>();  




        public ICollection<MembersBookingSessions> MembersBooking { get; set; } =new List<MembersBookingSessions>();
    }
}

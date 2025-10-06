using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDataAccsess.Models
{
    public class MembersBookingSessions :BaseEntities
    {


        public bool IsAttended { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; } = null!;


        public int SessionId { get; set; }

        public Sessions  sessions { get; set; } = null!;
    }
}
